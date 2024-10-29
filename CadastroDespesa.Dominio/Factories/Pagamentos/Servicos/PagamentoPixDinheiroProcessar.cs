using System;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;

public class PagamentoPixDinheiroProcessar : IPagamentoPixDinheiroProcessar
{
    private  readonly IDespesaRepositorio despesasRepositorio;

    public PagamentoPixDinheiroProcessar(IDespesaRepositorio despesasRepositorio)
    {
        this.despesasRepositorio = despesasRepositorio;
    }

    public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
    {
        await ProcessarPagamentoPixEDinheiro(despesa);
       
    }

    public async Task ProcessarPagamentoPixEDinheiro(Despesa despesa)
    {
        despesa.SetStatusPagamento(true);
        await despesasRepositorio.Alterar(despesa);
    }
}
