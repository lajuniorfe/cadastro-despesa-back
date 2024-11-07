using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Fatories.Pagamentos
{
    public class ProcessamentoPagamentoFactory
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly ProcessamentoTipoDespesaFactory processamentoTipoDespesaFactory;
        private readonly ITipoPagamentoServico tipoPagamentoServico;

        public ProcessamentoPagamentoFactory(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, ProcessamentoTipoDespesaFactory processamentoTipoDespesaFactory, ITipoPagamentoServico tipoPagamentoServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            this.processamentoTipoDespesaFactory = processamentoTipoDespesaFactory;
            this.tipoPagamentoServico = tipoPagamentoServico;
        }

        public virtual IPagamentoProcessar ProcessarPagamento(int idTipoPagamento)
        {
            return idTipoPagamento switch
            {
                1 => new PagamentoCartaoProcessar(cartaoServico, faturaServico, parcelaServico, processamentoTipoDespesaFactory, tipoPagamentoServico),
                2 => new PagamentoPixDinheiroProcessar(processamentoTipoDespesaFactory, tipoPagamentoServico),
                3 => new PagamentoBoletoProcessar(tipoPagamentoServico, processamentoTipoDespesaFactory),
                _ => throw new ArgumentException("Tipo Pagamento não suportado")
            };
        }
    }
}
