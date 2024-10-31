using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Fatories.Pagamentos
{
    public class ProcessamentoPagamentoFactory
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly IDespesaRepositorio despesasRepositorio;
        private readonly ProcessamentoTipoDespesaFactory processamentoTipoDespesaFactory;

        public ProcessamentoPagamentoFactory(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, IDespesaRepositorio despesasRepositorio, ProcessamentoTipoDespesaFactory processamentoTipoDespesaFactory)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            this.despesasRepositorio = despesasRepositorio;
            this.processamentoTipoDespesaFactory = processamentoTipoDespesaFactory;
        }

        public IPagamentoProcessar ProcessarPagamento(int idTipoPagamento)
        {
            return idTipoPagamento switch
            {
                1 => new PagamentoCartaoProcessar(cartaoServico, faturaServico, parcelaServico, processamentoTipoDespesaFactory),
                2 => new PagamentoPixDinheiroProcessar(despesasRepositorio, processamentoTipoDespesaFactory),
                _ => throw new ArgumentException("Tipo Pagamento não suportado")
            };
        }
    }
}
