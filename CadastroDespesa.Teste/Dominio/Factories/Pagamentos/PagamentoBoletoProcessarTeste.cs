using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using Moq;

namespace CadastroDespesa.Teste.Dominio.Factories.Pagamentos
{
    public class PagamentoBoletoProcessarTeste
    {
        private readonly Mock<ITransacaoDespesaRepositorio> transacaoDespesaRepositorio;
        private readonly Mock<ITipoPagamentoServico> _tipoPagamentoServicoMock;
        private readonly Mock<ProcessamentoTipoDespesaFactory> _tipoDespesaFactoryMock;
        private readonly Mock<ITipoDepesaProcessar> _tipoDespesaProcessarMock;
        private readonly PagamentoBoletoProcessar _pagamentoBoletoProcessar;
        public PagamentoBoletoProcessarTeste()
        {
            _tipoPagamentoServicoMock = new Mock<ITipoPagamentoServico>();
            _tipoDespesaFactoryMock = new Mock<ProcessamentoTipoDespesaFactory>();
            _tipoDespesaProcessarMock = new Mock<ITipoDepesaProcessar>();
            transacaoDespesaRepositorio = new Mock<ITransacaoDespesaRepositorio>();
            var tipoDespesaFactory = new ProcessamentoTipoDespesaFactory(transacaoDespesaRepositorio.Object);
            _pagamentoBoletoProcessar = new PagamentoBoletoProcessar(_tipoPagamentoServicoMock.Object, tipoDespesaFactory);
        }

        [Fact]
        public async Task Quando_Tipo_pagamento_For_Boleto_Espero_processar_Pagamento_Boleto()
        {
            int idTipoDespesa = 1;
            var tipoDespesa = new TipoDespesa { Id = idTipoDespesa };
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();

            Despesa despesa = new(descricao, valor, data, categoria.Object, tipoDespesa);

            var transacaoDespesaRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();

            _tipoDespesaFactoryMock
                .Setup(factory => factory.ProcessarTipoDespesa(It.IsAny<int>()))
                .Returns(_tipoDespesaProcessarMock.Object);

            await _pagamentoBoletoProcessar.Processar(despesa, 0, 0);
            await _pagamentoBoletoProcessar.ProcessarPagamentoBoleto(despesa);

        }
    }

}
