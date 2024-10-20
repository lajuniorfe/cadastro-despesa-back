using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;

namespace CadastroDespesa.Dominio.Despesas.Servicos;

public class DespesaServico
{
    private readonly IDespesasRepositorio despesasRepositorio;

    public DespesaServico(IDespesasRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public Despesa ValidarDespesa(int idDespesa){
        return despesasRepositorio.Recuperar(idDespesa);
    }
}
