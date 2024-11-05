using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;

namespace CadastroDespesa.Teste.Dominio.Factories.Pagamentos
{
    public class PagamentoCartaoProcessarTeste
    {
        private readonly Mock<ITransacaoDespesaRepositorio> transacaoDespesaRepositorio;
        private readonly Mock<ITipoPagamentoServico> _tipoPagamentoServicoMock;
        private readonly Mock<ICartaoServico> _cartaoServicoMock;
        private readonly Mock<IFaturaServico> _faturaServicoMock;
        private readonly Mock<IParcelaServico> _parcelaServicoMock;
        private readonly Mock<ProcessamentoTipoDespesaFactory> _tipoDespesaFactoryMock;
        private readonly Mock<ITipoDepesaProcessar> _tipoDespesaProcessarMock;
        private readonly PagamentoCartaoProcessar _pagamentoCartaoProcessar;

        public PagamentoCartaoProcessarTeste()
        {

            _tipoPagamentoServicoMock = new Mock<ITipoPagamentoServico>();
            _tipoDespesaFactoryMock = new Mock<ProcessamentoTipoDespesaFactory>();
            _tipoDespesaProcessarMock = new Mock<ITipoDepesaProcessar>();
            transacaoDespesaRepositorio = new Mock<ITransacaoDespesaRepositorio>();
            _cartaoServicoMock = new Mock<ICartaoServico>();
            _faturaServicoMock = new Mock<IFaturaServico>();
            _parcelaServicoMock = new Mock<IParcelaServico>();
            var tipoDespesaFactory = new ProcessamentoTipoDespesaFactory(transacaoDespesaRepositorio.Object);
            _pagamentoCartaoProcessar = new PagamentoCartaoProcessar(
                _cartaoServicoMock.Object, _faturaServicoMock.Object,
                _parcelaServicoMock.Object, tipoDespesaFactory, _tipoPagamentoServicoMock.Object);

        }

        [Fact]
        public async Task Quando_Tipo_Pagamento_For_Cartao_E_Nao_Houver_Fatura_Espero_Processar_Pagamento_Cartao()
        {

            int idTipoDespesa = 1;
            int idCartao = 1;
            int parcelas = 2;
            var tipoDespesa = new TipoDespesa { Id = idTipoDespesa };
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();
            var parcela = new Parcela();

            Despesa despesa = new(descricao, valor, data, categoria.Object, tipoDespesa);

            var transacaoDespesaRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();

            _parcelaServicoMock.Setup(p => p.InstanciarParcela()).Returns(parcela);

            _tipoDespesaFactoryMock
                .Setup(factory => factory.ProcessarTipoDespesa(It.IsAny<int>()))
                .Returns(_tipoDespesaProcessarMock.Object);

            await _pagamentoCartaoProcessar.Processar(despesa, idCartao, parcelas);
            await _pagamentoCartaoProcessar.ProcessarPagamentoCartao(despesa, idCartao, parcelas);
        }

        [Fact]
        public async Task Quando_Tipo_Pagamento_For_Cartao_E_Houver_Fatura_Espero_Processar_Pagamento_Cartao()
        {

            int idTipoDespesa = 1;
            int idCartao = 1;
            int parcelas = 2;
            var tipoDespesa = new TipoDespesa { Id = idTipoDespesa };
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();
            var parcela = new Parcela();
            var fatura = new Fatura();

            Despesa despesa = new(descricao, valor, data, categoria.Object, tipoDespesa);

            var transacaoDespesaRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();

            _parcelaServicoMock.Setup(p => p.InstanciarParcela()).Returns(parcela);

            _faturaServicoMock.Setup(p => p.VerificarFaturaCartaoAsync(idCartao, valor, data))
                .ReturnsAsync(fatura);

            _tipoDespesaFactoryMock
                .Setup(factory => factory.ProcessarTipoDespesa(It.IsAny<int>()))
                .Returns(_tipoDespesaProcessarMock.Object);

            await _pagamentoCartaoProcessar.Processar(despesa, idCartao, parcelas);
            await _pagamentoCartaoProcessar.ProcessarPagamentoCartao(despesa, idCartao, parcelas);
        }
    }
}
