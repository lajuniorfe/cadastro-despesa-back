using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using CadastroDespesa.Dominio.TiposPagamento.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.TiposPagamentos.Servicos
{
    public class TipoPgamentoServicoTeste
    {
        private readonly Mock<ITipoPagamentoRepositorio> _tipoPagamentoRepositorioMock;
        private readonly TipoPagamentoServico _tipoPagamentoServico;

        public TipoPgamentoServicoTeste()
        {
            _tipoPagamentoRepositorioMock = new Mock<ITipoPagamentoRepositorio>();
            _tipoPagamentoServico = new TipoPagamentoServico(_tipoPagamentoRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_TipoPagamento_Espero_Retornar_TipoPagamento_Valido()
        {
            int idTipoPagamento = 1;

            var tipoPagamentoValido = new Mock<TipoPagamento>();
            _tipoPagamentoRepositorioMock.Setup(r => r.ObterPorId(idTipoPagamento))
                .ReturnsAsync(tipoPagamentoValido.Object);

            var tipoPagamentoRetornado = await _tipoPagamentoServico.ValidarPagamentoAsync(idTipoPagamento);

            Assert.NotNull(tipoPagamentoRetornado);
        }
    }
}
