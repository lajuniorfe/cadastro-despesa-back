using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Enums;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Dominio.Worker.Producer.Interface;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico : IDespesaServico
{
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ICategoriaServico categoriaServico;
    private readonly ITipoDespesaServico tipoDespesaServico;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartaoServico cartaoServico;
    private readonly IRabbitProducer rabbitProducer;
    private readonly ProcessamentoPagamentoFactory _pagamentoFactory;

    public DespesaServico(IDespesaRepositorio despesasRepositorio, ICategoriaServico categoriaServico, ITipoDespesaServico tipoDespesaServico, IUnitOfWork unitOfWork, ICartaoServico cartaoServico, ProcessamentoPagamentoFactory pagamentoFactory, IRabbitProducer rabbitProducer)
    {
        this.despesasRepositorio = despesasRepositorio;
        this.categoriaServico = categoriaServico;
        this.tipoDespesaServico = tipoDespesaServico;
        this.unitOfWork = unitOfWork;
        this.cartaoServico = cartaoServico;
        _pagamentoFactory = pagamentoFactory;
        this.rabbitProducer = rabbitProducer;
    }

    public async Task<Despesa> ValidarDespesaAsync(int idDespesa)
    {
        return await despesasRepositorio.ObterPorId(idDespesa);
    }

    public async Task<Despesa> InstanciaDespesaParaCadastro(string descricao, decimal valor, DateTime data, int idCategoria, int idTipoDespesa)
    {

        Categoria categoria = await categoriaServico.ValidarCategoriaAsync(idCategoria);

        TipoDespesa tipoDespesa = await tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);

        Despesa despesa = new(descricao, valor, data, categoria, tipoDespesa);

        return despesa;
    }

    public async Task PersistirDespesas(DespesaPersistencia request, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.BeginTransaction();

            Categoria categoriaRetornada = await categoriaServico.BuscarCategoriaNomeAsync(request.Categoria);
          
            var retorno = RemoverAcentos(request.TipoDespesa);

            if (retorno.Contains("&"))
                retorno = retorno.Replace("&", "e");

            TipoDespesa tipoDespesaRetornada = await tipoDespesaServico.BuscarTipoDespesaNomeAsync(retorno);
            Cartao cartaoRetornado = new();
            Despesa despesa = new();

            if (Enum.TryParse(typeof(EnumDespesaCartao),
                request.FormaPagamento.Trim(), true, out var resultado) &&
                Enum.IsDefined(typeof(EnumDespesaCartao), resultado))
            {
                var enumValue = (EnumDespesaCartao)resultado;

                var descricao = enumValue.GetDescription();

                cartaoRetornado = await cartaoServico.BuscarCartaoNomeAsync(descricao);

                despesa = await InstanciaDespesaParaCadastro(
               request.NomeDespesa, request.Valor, request.DataCriacao, categoriaRetornada.Id,
               tipoDespesaRetornada.Id);

                Console.WriteLine("o erro é aqui:", despesa);
                await despesasRepositorio.Criar(despesa);

                IPagamentoProcessar processadorPagamento = _pagamentoFactory.ProcessarPagamento(1);

                await processadorPagamento
                   .Processar(
                       despesa,
                       cartaoRetornado.Id,
                       request.Parcela == 0 ? 1 : request.Parcela
                   );
            }
            else
            {
                despesa = await InstanciaDespesaParaCadastro(
                              request.NomeDespesa, request.Valor, request.DataCriacao, categoriaRetornada.Id,
                              tipoDespesaRetornada.Id);

                Console.WriteLine("o erro é aqui:", despesa);
                await despesasRepositorio.Criar(despesa);

                var pagamento = request.FormaPagamento.Trim() == "Pix" ? 2 : 3;

                IPagamentoProcessar processadorPagamento = _pagamentoFactory.ProcessarPagamento(pagamento);

                await processadorPagamento
                   .Processar(
                       despesa,
                       cartaoRetornado.Id,
                       request.Parcela
                   );
            }

            await unitOfWork.CommitAsync();

            //tratar o retorno para a planilha
            //
            await rabbitProducer.DispararFilaPersistenciaDespesaConcluida(request.Identificador, cancellationToken);
        }
        catch
        {
            await unitOfWork.RollbackAsync();
        }

    }

    public static string RemoverAcentos(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return texto;

        var textoNormalizado = texto.Normalize(NormalizationForm.FormD);
        var regex = new Regex(@"[\p{Mn}]"); // Mn = Mark, Nonspacing (acentos e diacríticos)
        return regex.Replace(textoNormalizado, "")
                    .Normalize(NormalizationForm.FormC);
    }



}
