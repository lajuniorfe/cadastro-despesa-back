using System;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;

public class PagamentoDinheiroProcessar : IPagamentoDinheiroProcessar
{
    private  readonly IDespesaRepositorio despesasRepositorio;

    public PagamentoDinheiroProcessar(IDespesaRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public async Task Processar(Despesa despesa, int idCartao, int totalParcelas)
    {
        ProcessarPagamentoDinheiro(despesa);
       
    }

    public void ProcessarPagamentoDinheiro(Despesa despesa)
    {
        despesa.SetStatusPagamento(true);
        despesasRepositorio.Alterar(despesa);
    }
}
