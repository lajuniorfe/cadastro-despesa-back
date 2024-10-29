using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico : IDespesaServico
{
    private readonly IDespesaRepositorio despesasRepositorio;

    public DespesaServico(IDespesaRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public async Task<Despesa> ValidarDespesaAsync(int idDespesa){
        return await despesasRepositorio.ObterPorId(idDespesa);
    }

}
