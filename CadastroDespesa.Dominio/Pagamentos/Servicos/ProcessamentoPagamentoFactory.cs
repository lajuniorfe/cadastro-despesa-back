using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Pagamentos.PagamentoCartao;
using CadastroDespesa.Dominio.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Pagamentos.Servicos
{
    public class ProcessamentoPagamentoFactory
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;

        public ProcessamentoPagamentoFactory(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;   
        }

        public IProcessarPagamento ProcessarPagamento(int idTipoPagamento)
        {
            return idTipoPagamento switch
            {
                2 => new ProcessarPagamentoCartao(cartaoServico, faturaServico, parcelaServico),
                _ => throw new ArgumentException("Tipo Pagamento não suportado")
            };
        }
    }
}
