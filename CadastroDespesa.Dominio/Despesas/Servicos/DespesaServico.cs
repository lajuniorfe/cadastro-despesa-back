using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico : IDespesaServico
{
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ICategoriaServico categoriaServico;
    private readonly ITipoDespesaServico tipoDespesaServico;


    public DespesaServico(IDespesaRepositorio despesasRepositorio, ICategoriaServico categoriaServico, ITipoDespesaServico tipoDespesaServico)
    {
        this.despesasRepositorio = despesasRepositorio;
        this.categoriaServico = categoriaServico;
        this.tipoDespesaServico = tipoDespesaServico;
    }

    public async Task<Despesa> ValidarDespesaAsync(int idDespesa){
        return await despesasRepositorio.ObterPorId(idDespesa);
    }

    public async Task<Despesa> InstanciaDespesaParaCadastro(string descricao, decimal valor, DateTime data,  int idCategoria, int idTipoDespesa)
    {

        Categoria categoria = await categoriaServico.ValidarCategoriaAsync(idCategoria);

        TipoDespesa tipoDespesa = await tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);

        Despesa despesa = new(descricao, valor, data, categoria, tipoDespesa);

        return despesa;
    }

}
