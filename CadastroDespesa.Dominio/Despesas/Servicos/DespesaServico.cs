using System;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico : IDespesaServico
{
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ICategoriaServico categoriaServico;
    private readonly ITipoDespesaServico tipoDespesaServico;
    private readonly ITipoPagamentoServico tipoPagamentoServico;


    public DespesaServico(IDespesaRepositorio despesasRepositorio, ICategoriaServico categoriaServico, ITipoDespesaServico tipoDespesaServico, ITipoPagamentoServico tipoPagamentoServico)
    {
        this.despesasRepositorio = despesasRepositorio;
        this.categoriaServico = categoriaServico;
        this.tipoDespesaServico = tipoDespesaServico;
        this.tipoPagamentoServico = tipoPagamentoServico;
    }

    public async Task<Despesa> ValidarDespesaAsync(int idDespesa){
        return await despesasRepositorio.ObterPorId(idDespesa);
    }
    public async Task<Despesa> InstanciaDespesaParaCadastro(string descricao, decimal valor, int idCategoria, int idTipoDespesa, int idTipoPagamento)
    {

        Categoria categoria = await categoriaServico.ValidarCategoriaAsync(idCategoria);

        TipoPagamento tipoPagamento = await tipoPagamentoServico.ValidarPagamentoAsync(idTipoPagamento);

        TipoDespesa tipoDespesa = await tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);

        Despesa despesa = new(descricao, valor, categoria, tipoDespesa, tipoPagamento);

        return despesa;
    }

}
