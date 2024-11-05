using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Dominio.TipoDespesas.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.TiposDespesas.Servicos
{
    public class TipoDespesaServicoTeste
    {
        private readonly Mock<ITipoDespesaRepositorio> _tipoDespesaRepositorioMock;
        private readonly TipoDespesaServico _tipoDespesaServico;

        public TipoDespesaServicoTeste()
        {
            _tipoDespesaRepositorioMock = new Mock<ITipoDespesaRepositorio>();
            _tipoDespesaServico = new TipoDespesaServico(_tipoDespesaRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_TipoDespesa_Espero_Retornar_TipoDespesa_Valido()
        {
            int idTipoDespesa = 1;
            var tipoDespesaValido = new Mock<TipoDespesa>();
            _tipoDespesaRepositorioMock.Setup(r => r.ObterPorId(idTipoDespesa))
                                   .ReturnsAsync(tipoDespesaValido.Object);

            var tipoDespesaRetornado = await _tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);

            Assert.NotNull(tipoDespesaRetornado);
        }
    }
}
