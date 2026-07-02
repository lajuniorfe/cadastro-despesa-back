using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Repositorios;
using CadastroDespesa.Dominio.Recorrencias.Servicos;
using Moq;

namespace CadastroDespesa.Teste.Dominio.TiposDespesas.Servicos
{
    public class TipoDespesaServicoTeste
    {
        private readonly Mock<IRecorrenciaRepositorio> _tipoDespesaRepositorioMock;
        private readonly RecorrenciaServico _tipoDespesaServico;

        public TipoDespesaServicoTeste()
        {
            _tipoDespesaRepositorioMock = new Mock<IRecorrenciaRepositorio>();
            _tipoDespesaServico = new RecorrenciaServico(_tipoDespesaRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_TipoDespesa_Espero_Retornar_TipoDespesa_Valido()
        {
            int idTipoDespesa = 1;
            var tipoDespesaValido = new Mock<Recorrencia>();
            _tipoDespesaRepositorioMock.Setup(r => r.ObterPorId(idTipoDespesa))
                                   .ReturnsAsync(tipoDespesaValido.Object);

            var tipoDespesaRetornado = await _tipoDespesaServico.ValidarRecorrenciaAsync(idTipoDespesa);

            Assert.NotNull(tipoDespesaRetornado);
        }
    }
}
