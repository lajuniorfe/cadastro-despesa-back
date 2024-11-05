using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Cartoes.Servicos
{
    public class CartaoServicoTeste
    {
        private readonly Mock<ICartaoRepositorio> _cartaoRepositorioMock;
        private readonly CartaoServico _cartaoServico;

        public CartaoServicoTeste()
        {
            _cartaoRepositorioMock = new Mock<ICartaoRepositorio>();
            _cartaoServico = new CartaoServico(_cartaoRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_Cartao_Espero_Retornar_Cartao_Valido()
        {
            int idCartao = 1;
            var cartaoValido = new Mock<Cartao>();
            _cartaoRepositorioMock.Setup(r => r.ObterPorId(idCartao))
                                   .ReturnsAsync(cartaoValido.Object);

            var cartaoRetornado = await _cartaoServico.ValidarCartaoAsync(idCartao);

            Assert.NotNull(cartaoRetornado); 
        }
    }
}
