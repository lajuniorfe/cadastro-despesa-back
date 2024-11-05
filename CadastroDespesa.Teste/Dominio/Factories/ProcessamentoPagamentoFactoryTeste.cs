using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Factories
{
    public class ProcessamentoPagamentoFactoryTeste
    {
        private readonly Mock<ICartaoServico> cartaoServicoMock;
        private readonly Mock<IFaturaServico> faturaServicoMock;
        private readonly Mock<IParcelaServico> parcelaServicoMock;
        private readonly Mock<IDespesaRepositorio> despesaRepositorioMock;
        private readonly Mock<ITipoPagamentoServico> tipoPagamentoServicoMock;
        private readonly Mock<ITransacaoDespesaRepositorio> transacaoDespesaRepositorioMock;
        private readonly ProcessamentoTipoDespesaFactory tipoDespesafactoryMock;
        private readonly ProcessamentoPagamentoFactory processamentoPagamentoFactory;

        public ProcessamentoPagamentoFactoryTeste()
        {
            cartaoServicoMock = new Mock<ICartaoServico>();
            faturaServicoMock = new Mock<IFaturaServico>();
            parcelaServicoMock = new Mock<IParcelaServico>();
            despesaRepositorioMock = new Mock<IDespesaRepositorio>();
            tipoPagamentoServicoMock = new Mock<ITipoPagamentoServico>();
            transacaoDespesaRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();
            tipoDespesafactoryMock = new ProcessamentoTipoDespesaFactory(transacaoDespesaRepositorioMock.Object);

            processamentoPagamentoFactory = new ProcessamentoPagamentoFactory(cartaoServicoMock.Object, faturaServicoMock.Object,
                parcelaServicoMock.Object, despesaRepositorioMock.Object, tipoDespesafactoryMock, tipoPagamentoServicoMock.Object);
        }

        [Fact]
        public void Quando_Processar_Pagamento_For_TipoPagamento_Cartao_Espero_Processar_Pagamento_Cartao()
        {
            int idTipoPagamento = 1;
            var resultado = processamentoPagamentoFactory.ProcessarPagamento(idTipoPagamento);
            Assert.IsType<PagamentoCartaoProcessar>(resultado);
        }

        [Fact]
        public void Quando_Processar_Pagamento_For_TipoPagamento_PixDinheiro_Espero_Processar_Pagamento_PixDinheiro()
        {
            int idTipoPagamento = 2;
            var resultado = processamentoPagamentoFactory.ProcessarPagamento(idTipoPagamento);
            Assert.IsType<PagamentoPixDinheiroProcessar>(resultado);
        }

        [Fact]
        public void Quando_Processar_Pagamento_For_TipoPagamento_Boleto_Espero_Processar_Pagamento_Boleto()
        {
            int idTipoPagamento = 3;
            var resultado = processamentoPagamentoFactory.ProcessarPagamento(idTipoPagamento);
            Assert.IsType<PagamentoBoletoProcessar>(resultado);

        }

        [Fact]
        public void Quando_Processar_Pagamento_For_TipoPagamento_Nao_Esperado_Exception()
        {
            int idTipoPagamento = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                processamentoPagamentoFactory.ProcessarPagamento(idTipoPagamento);
            });
        }
    }
}
