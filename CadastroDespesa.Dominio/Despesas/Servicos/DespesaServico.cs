using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Dominio.Worker.Producer.Interface;
using System.Text;
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

    public DespesaServico(IDespesaRepositorio despesasRepositorio, ICategoriaServico categoriaServico, ITipoDespesaServico tipoDespesaServico, IUnitOfWork unitOfWork, ICartaoServico cartaoServico, IRabbitProducer rabbitProducer)
    {
        this.despesasRepositorio = despesasRepositorio;
        this.categoriaServico = categoriaServico;
        this.tipoDespesaServico = tipoDespesaServico;
        this.unitOfWork = unitOfWork;
        this.cartaoServico = cartaoServico;
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


        return null;
    }

    public async Task PersistirDespesas(DespesaPersistencia request, CancellationToken cancellationToken)
    {
        try
        {
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
