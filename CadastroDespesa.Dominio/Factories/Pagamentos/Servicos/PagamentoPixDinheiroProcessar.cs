using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;

public class PagamentoPixDinheiroProcessar : IPagamentoPixDinheiroProcessar
{
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;

    public PagamentoPixDinheiroProcessar(IDespesaRepositorio despesasRepositorio, ProcessamentoTipoDespesaFactory tipoDespesaFactory)
    {
        this.despesasRepositorio = despesasRepositorio;
        _tipoDespesaFactory = tipoDespesaFactory;
    }

    public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
    {
        await ProcessarPagamentoPixEDinheiro(despesa);
       
    }

    public async Task ProcessarPagamentoPixEDinheiro(Despesa despesa)
    {
        despesa.SetStatusPagamento(true);
        await despesasRepositorio.Alterar(despesa);

        ITipoDepesaProcessar processadorTipoDespesa = _tipoDespesaFactory.ProcessarTipoDespesa(despesa.TipoDespesa.Id);

        await processadorTipoDespesa.Processar(despesa, 1, true, despesa.Valor);
    }
}
