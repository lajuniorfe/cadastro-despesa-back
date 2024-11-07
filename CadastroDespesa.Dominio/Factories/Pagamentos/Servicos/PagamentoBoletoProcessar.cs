using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos
{
    public class PagamentoBoletoProcessar : IPagamentoBoletoProcessar
    {
        private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;
        private readonly ITipoPagamentoServico tipoPagamentoServico;

        public PagamentoBoletoProcessar(ITipoPagamentoServico tipoPagamentoServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory)
        {
            this.tipoPagamentoServico = tipoPagamentoServico;
            _tipoDespesaFactory = tipoDespesaFactory;
        }

        public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
        {
            await ProcessarPagamentoBoleto(despesa);
        }

        public async Task ProcessarPagamentoBoleto(Despesa despesa)
        {
            ITipoDepesaProcessar processadorTipoDespesa = _tipoDespesaFactory.ProcessarTipoDespesa(
                despesa.TipoDespesa is not null ? despesa.TipoDespesa.Id : 0);
            TipoPagamento tipoPagamento = await tipoPagamentoServico.ValidarPagamentoAsync(3);
            await processadorTipoDespesa.Processar(despesa, tipoPagamento, 1, true, despesa.Valor);

        }
    }
}
