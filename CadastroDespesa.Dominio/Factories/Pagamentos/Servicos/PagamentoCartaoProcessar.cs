using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos
{
    public class PagamentoCartaoProcessar : IPagamentoCartaoProcessar
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;
        private readonly ITipoPagamentoServico tipoPagamentoServico;

        public PagamentoCartaoProcessar(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory, ITipoPagamentoServico tipoPagamentoServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            _tipoDespesaFactory = tipoDespesaFactory;
            this.tipoPagamentoServico = tipoPagamentoServico;
        }

        public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
        {
            await ProcessarPagamentoCartao(despesa, idCartao.HasValue ? idCartao.Value : 0, totalParcelas.HasValue ? totalParcelas.Value : 0);
        }

        public async Task ProcessarPagamentoCartao(Despesa despesa, int idCartao, int totalParcelas)
        {
            Cartao cartaoRetornado = await cartaoServico.ValidarCartaoAsync(idCartao);

            IList<Parcela> parcelas = Parcela.CalcularDataParcela(totalParcelas, despesa);

            DateTime dataFatura = Fatura.CalcularDataFatura(despesa.Data, cartaoRetornado.Fechamento);
            for (var item = 0; item < parcelas.Count; item++)
            {

                dataFatura = item == 0 ? dataFatura : dataFatura.AddMonths(1);
                Fatura faturaRetornada = await faturaServico.VerificarFaturaCartaoAsync(idCartao, dataFatura);

                if (faturaRetornada != null)
                {
                    faturaRetornada = await faturaServico.AlterarFaturaCartaoExistenteAsync(faturaRetornada, parcelas[item].Valor);
                }
                else
                {
                    faturaRetornada = await faturaServico.CriarFaturaCartaoAsync(dataFatura, cartaoRetornado, parcelas[item].Valor);
                }

                parcelas[item].SetData(dataFatura);
                parcelas[item].SetFatura(faturaRetornada);
                await parcelaServico.CriarParcelasDespesa(parcelas[item]);
            }

            ITipoDepesaProcessar processadorTipoDespesa = _tipoDespesaFactory.ProcessarTipoDespesa(despesa.TipoDespesa is not null ? despesa.TipoDespesa.Id : 0);

            TipoPagamento tipoPagamento = await tipoPagamentoServico.ValidarPagamentoAsync(2);

            await processadorTipoDespesa.Processar(despesa, tipoPagamento, parcelas.Count, true, parcelas[0].Valor);

        }
    }
}
