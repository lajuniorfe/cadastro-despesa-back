using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using CadastroDespesa.Dominio.TransacoesDespesas.Servicos;
using Moq;

namespace CadastroDespesa.Teste.Dominio.TransacoesDespesas.Servicos
{
    public class TransacaoDespesaServicoTeste
    {
        private readonly Mock<ITransacaoDespesaRepositorio> _transacaoRepositorioMock;
        private readonly TransacaoDespesaServico _transacaoDespesaServico;

        public TransacaoDespesaServicoTeste()
        {
            _transacaoRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();
            _transacaoDespesaServico = new TransacaoDespesaServico(_transacaoRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_TransacaoDespesa_Espero_Retornar_TransacaoDespesa_Valida()
        {
            int idTransacaoDespesa = 1;

            var transacaoValida = new Mock<TransacaoDespesa>();
            _transacaoRepositorioMock.Setup(r => r.ObterPorId(idTransacaoDespesa))
                .ReturnsAsync(transacaoValida.Object);

            var transacaoRetornada = await _transacaoDespesaServico
                .ValidarTransacaoDespesaAsync(idTransacaoDespesa);

            Assert.NotNull(transacaoRetornada);
        }
    }
}


//1 => new TipoDespesaFixaProcessar(transacaoDespesaRepositorio),
// 	0   29                      2 => new TipoDespesaVariavelProcessar(transacaoDespesaRepositorio),
// 	0   30                      3 => new TipoDespesaRecorrenteProcessar(transacaoDespesaRepositorio),
// 	0   31                      4 => new TipoDespesaExtraordinariaProcessar(transacaoDespesaRepositorio),
// 	0   32                      5 => new TipoDespesaEmergencialProcessar(transacaoDespesaRepositorio),
// 	0   33                      6 => new TipoDespesaConvenienciaProcessar(transacaoDespesaRepositorio),
// 	0   34                      _ => throw new ArgumentException("Tipo Despesa não suportado")