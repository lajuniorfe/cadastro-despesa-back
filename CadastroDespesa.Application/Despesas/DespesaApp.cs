using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ProcessamentoPagamentoFactory _pagamentoFactory;
    private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartaoServico cartaoServico;
    private readonly ICategoriaServico categoriaServico;
    private readonly ITipoPagamentoServico tipoPagamentoServico;
    private readonly ITipoDespesaServico tipoDespesaServico;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, ProcessamentoPagamentoFactory _pagamentoFactory, IUnitOfWork unitOfWork, ICartaoServico cartaoServico, ICategoriaServico categoriaServico, ITipoPagamentoServico tipoPagamentoServico, ITipoDespesaServico tipoDespesaServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory)
    {
        _mapper = mapper;
        this._pagamentoFactory = _pagamentoFactory;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.cartaoServico = cartaoServico;
        this.categoriaServico = categoriaServico;
        this.tipoPagamentoServico = tipoPagamentoServico;
        this.tipoDespesaServico = tipoDespesaServico;
        _tipoDespesaFactory = tipoDespesaFactory;
    }

    public async Task<IList<DespesaResponse>> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = await despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas); ;
    }

    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        try
        {
            //ajustar tudo aqui

            //usar fluent validator
            await unitOfWork.BeginTransaction();

            Categoria categoria = await categoriaServico.ValidarCategoriaAsync(despesaRequest.IdCategoria);

            TipoPagamento tipoPagamento = await tipoPagamentoServico.ValidarPagamentoAsync(despesaRequest.IdTipoPagamento);
            Despesa despesa = new(despesaRequest.Descricao, despesaRequest.Valor, categoria, null, tipoPagamento);

            ITipoDepesaProcessar processadorTipoDespesa = _tipoDespesaFactory
                                .ProcessarTipoDespesa(despesaRequest.IdTipoDespesa);

            await processadorTipoDespesa.Processar(despesaRequest.IdTipoDespesa, tipoPagamento.Id, despesa);

            await despesasRepositorio.Criar(despesa);

            IPagamentoProcessar processadorPagamento = _pagamentoFactory.ProcessarPagamento(despesaRequest.IdTipoPagamento);

            await processadorPagamento
                .Processar(
                    despesa,
                    despesaRequest.IdCartao.HasValue ?
                    despesaRequest.IdCartao.Value : 0,
                    despesaRequest.Parcela.HasValue ?
                    despesaRequest.Parcela.Value : 0
                );

            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            //criar log
            Console.WriteLine($"Erro: {ex.Message}");
            throw;
        }


    }
}
