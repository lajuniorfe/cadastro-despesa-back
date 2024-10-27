using System;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;

public class PagamentoDinheiroProcessar : IPagamentoDinheiroProcessar
{
    private  readonly IDespesasRepositorio despesasRepositorio;

    public PagamentoDinheiroProcessar(IDespesasRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public async Task Processar(Despesa despesa, Cartao cartao, int totalParcelas)
    {
        ProcessarPagamentoDinheiro(despesa);
       
    }

    public void ProcessarPagamentoDinheiro(Despesa despesa)
    {
        despesa.SetStatusPagamento(true);
        despesasRepositorio.Alterar(despesa);
    }
}
