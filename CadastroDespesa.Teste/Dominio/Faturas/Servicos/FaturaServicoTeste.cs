using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Dominio.Faturas.Servicos;
using Moq;

namespace CadastroDespesa.Teste.Dominio.Faturas.Servicos
{
    public class FaturaServicoTeste
    {
        private readonly Mock<IFaturaRepositorio> _faturaRepositorioMock;
        private readonly FaturaServico _faturaServico;
        private readonly Mock<FaturaServico> _faturaServicoMock;
        private readonly Mock<ICartaoRepositorio> _cartaoRepositorioMock;
        private readonly CartaoServico _cartaoServico;

        public FaturaServicoTeste()
        {
            _faturaRepositorioMock = new Mock<IFaturaRepositorio>();
            _faturaServico = new FaturaServico(_faturaRepositorioMock.Object);
            _cartaoRepositorioMock = new Mock<ICartaoRepositorio>();
            _cartaoServico = new CartaoServico(_cartaoRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_Fatura_Espero_Retornar_Fatura_Valida()
        {
            int idFatura = 1;
            var faturaValida = new Mock<Fatura>();
            _faturaRepositorioMock.Setup(r => r.ObterPorId(idFatura))
                .ReturnsAsync(faturaValida.Object);

            var faturaRetornada = await _faturaServico.ValidarFaturaAsync(idFatura);

            Assert.NotNull(faturaRetornada);
        }


        [Fact]
        public async Task Quando_Receber_Dados_Espero_Retornar_Fatura_Cartao()
        {

            int idCartao = 1;
            Cartao cartao = new Cartao();
            decimal valorDespesa = 10m;
            DateTime dataFatura = DateTime.Now;
            List<Fatura> faturas = new List<Fatura>();
            int vencimentoCartao = 10;


            _cartaoRepositorioMock
                .Setup(r => r.ObterPorId(idCartao)).ReturnsAsync(cartao);

            var cartaoValido = await _cartaoServico.ValidarCartaoAsync(idCartao);

            cartaoValido.SetVencimento(vencimentoCartao);

            _faturaRepositorioMock.Setup(r => r.Buscar(a => a.Cartao.Id == idCartao &&
                    (a.MesCorrespondente.Month == dataFatura.Month
                    && a.MesCorrespondente.Year == dataFatura.Year))).ReturnsAsync(faturas);

            var faturaCartaoRetornada = await _faturaServico.VerificarFaturaCartaoAsync(idCartao, valorDespesa, dataFatura);

            Assert.NotNull(faturaCartaoRetornada);
        }

        [Fact]
        public async Task Quando_Houver_Retorno_Fatura_Cartao_Espero_Alterar_Valor_Fatura_Cartao()
        {
            int idCartao = 1;
            Cartao cartao = new Cartao();
            DateTime dataFatura = DateTime.Now;
            int vencimentoCartao = 10;
            decimal valorFaturaInicial = 10m;

            _cartaoRepositorioMock
                .Setup(r => r.ObterPorId(idCartao)).ReturnsAsync(cartao);

            var cartaoValido = await _cartaoServico.ValidarCartaoAsync(idCartao);

            cartaoValido.SetVencimento(vencimentoCartao);

            Fatura faturaRetornada = new(valorFaturaInicial, dataFatura, dataFatura, cartao);

            _faturaRepositorioMock.Setup(r => r.Alterar(faturaRetornada));

            var faturaAlterada = await _faturaServico.AlterarFaturaCartaoExistenteAsync(faturaRetornada, valorFaturaInicial);

            Assert.NotEqual(valorFaturaInicial, faturaAlterada.Valor);
        }

        [Fact]
        public async Task Quando_Houver_Retorno_Nulo_Fatura_Cartao_Espero_Criar_Fatura_Cartao()
        {
            int idCartao = 1;
            Cartao cartao = new Cartao();
            DateTime dataFatura = DateTime.Now;
            int vencimentoCartao = 10;
            decimal valorFatura = 10m;
            _cartaoRepositorioMock
                .Setup(r => r.ObterPorId(idCartao)).ReturnsAsync(cartao);

            var cartaoValido = await _cartaoServico.ValidarCartaoAsync(idCartao);
            cartaoValido.SetVencimento(vencimentoCartao);

            Fatura fatura = new(valorFatura, dataFatura, dataFatura, cartao);
            
            _faturaRepositorioMock.Setup(r => r.Criar(fatura));

            var faturaCriada = await _faturaServico.CriarFaturaCartaoAsync(dataFatura, cartao, valorFatura);

            Assert.NotNull(faturaCriada);
        }
    }
}
