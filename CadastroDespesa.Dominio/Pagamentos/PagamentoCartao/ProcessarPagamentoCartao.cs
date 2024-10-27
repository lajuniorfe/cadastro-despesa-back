using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Pagamentos.PagamentoCartao
{
    public class ProcessarPagamentoCartao : IProcessarPagamento
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;

        public ProcessarPagamentoCartao(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
        }
        public async Task ProcessarPagamento(Despesa despesa, int idCartao, int totalParcelas)
        {
            Cartao cartaoRetornado = await cartaoServico.ValidarCartaoAsync(idCartao);
            Fatura faturaRetornada = await faturaServico.VerificarFaturaCartaoAsync(cartaoRetornado, despesa.Valor, despesa.Data);

            Parcela parcela = parcelaServico.InstanciarParcela();

            IList<Parcela> parcelas = parcela.CalcularDataParcela(totalParcelas, despesa);
            await parcelaServico.CriarParcelasDespesa(parcelas, faturaRetornada);
        }
    }
}
