using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos;
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
    public class ProcessamentoTipoDespesaFactoryTeste
    {
        private readonly Mock<ICartaoServico> cartaoServicoMock;
        private readonly Mock<IFaturaServico> faturaServicoMock;
        private readonly Mock<IParcelaServico> parcelaServicoMock;
        private readonly Mock<ITipoPagamentoServico> tipoPagamentoServicoMock;
        private readonly Mock<ITransacaoDespesaRepositorio> transacaoDespesaRepositorioMock;
        private readonly ProcessamentoTipoDespesaFactory tipoDespesafactoryMock;
        private readonly ProcessamentoPagamentoFactory processamentoPagamentoFactory;

        public ProcessamentoTipoDespesaFactoryTeste()
        {
            cartaoServicoMock = new Mock<ICartaoServico>();
            faturaServicoMock = new Mock<IFaturaServico>();
            parcelaServicoMock = new Mock<IParcelaServico>();
            tipoPagamentoServicoMock = new Mock<ITipoPagamentoServico>();
            transacaoDespesaRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();
            tipoDespesafactoryMock = new ProcessamentoTipoDespesaFactory(transacaoDespesaRepositorioMock.Object);

            processamentoPagamentoFactory = new ProcessamentoPagamentoFactory(cartaoServicoMock.Object, faturaServicoMock.Object,
                parcelaServicoMock.Object, tipoDespesafactoryMock, tipoPagamentoServicoMock.Object);
        }



        [Fact]
        public void Quando_Processar_TipoDespesa_Fixa_Espero_Processar_TipoDespesa_Fixa()
        {
            int idTipoDespesa = 1;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaFixaProcessar>(resultado);
        }

        [Fact]
        public void Quando_Processar_TipoDespesa_Variavel_Espero_Processar_TipoDespesa_Variavel()
        {
            int idTipoDespesa = 2;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaVariavelProcessar>(resultado);
        }

        [Fact]
        public void Quando_Processar_TipoDespesa_Recorrente_Espero_Processar_TipoDespesa_Recorrente()
        {
            int idTipoDespesa = 3;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaRecorrenteProcessar>(resultado);

        }

        [Fact]
        public void Quando_Processar_TipoDespesa_Extraordinaria_Espero_Processar_TipoDespesa_Extraordinaria()
        {
            int idTipoDespesa = 4;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaExtraordinariaProcessar>(resultado);

        }

        [Fact]
        public void Quando_Processar_TipoDespesa_Emergencial_Espero_Processar_TipoDespesa_Emergencial()
        {
            int idTipoDespesa = 5;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaEmergencialProcessar>(resultado);

        }

        [Fact]
        public void Quando_Processar_TipoDespesa_Conveniencia_Espero_Processar_TipoDespesa_Conveniencia()
        {
            int idTipoDespesa = 6;
            var resultado = tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            Assert.IsType<TipoDespesaConvenienciaProcessar>(resultado);

        }

        [Fact]
        public void Quando_Processar_TipoDespesa_For_TipoDespesa_Nao_Esperado_Espero_Exception()
        {
            int idTipoDespesa = 7;

            Assert.Throws<ArgumentException>(() =>
            {
                tipoDespesafactoryMock.ProcessarTipoDespesa(idTipoDespesa);
            });
        }
    }
}
