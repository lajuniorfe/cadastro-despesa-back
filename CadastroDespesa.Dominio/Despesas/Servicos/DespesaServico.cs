using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico : IDespesaServico
{
    private readonly IDespesasRepositorio despesasRepositorio;

    public DespesaServico(IDespesasRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public async Task<Despesa> ValidarDespesaAsync(int idDespesa){
        return await despesasRepositorio.ObterPorId(idDespesa);
    }
}
