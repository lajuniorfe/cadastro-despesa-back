using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Fatories.Pagamentos
{
    public class ProcessamentoPagamentoFactory
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly IDespesasRepositorio despesasRepositorio;

        public ProcessamentoPagamentoFactory(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, IDespesasRepositorio despesasRepositorio)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            this.despesasRepositorio = despesasRepositorio;
        }

        public IPagamentoProcessar ProcessarPagamento(int idTipoPagamento)
        {
            return idTipoPagamento switch
            {
                1 => new PagamentoDinheiroProcessar(despesasRepositorio),
                2 => new PagamentoCartaoProcessar(cartaoServico, faturaServico, parcelaServico),
                _ => throw new ArgumentException("Tipo Pagamento não suportado")
            };
        }
    }
}
