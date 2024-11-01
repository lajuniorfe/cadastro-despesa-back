using CadastroDespesa.Dominio.Cartoes.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Cartoes.Entidades
{
    public class CartaoTeste
    {
        [Fact]
        public void Quando_Instanciar_Cartao_Espero_Valores_Validos()
        {
            string nome = "Cartao teste";
            decimal limite = 100;
            int vencimento = 10;
            int fechamento = 10;

            Cartao cartao = new(nome, limite, vencimento, fechamento);

            Assert.Equal(nome, cartao.Nome);
            Assert.Equal(limite, cartao.Limite);
            Assert.Equal(vencimento, cartao.Vencimento);
            Assert.Equal(fechamento, cartao.Fechamento);

        }

        [Fact]
        public void Quando_Receber_Ultimo_Vencimento_Cartao_Espero_Proxima_Data_Vencimento()
        {
            DateTime dataVencimento = DateTime.Now;

            var cartaoMock = new Mock<Cartao>();

            var dataRecebida = cartaoMock.Object.CalcularProximaDataVencimento(dataVencimento);

            Assert.Equal(dataVencimento.Date.Month + 1, dataRecebida.Month);
        }

        [Fact]
        public void Quando_Receber_Ultimo_Fechamento_Cartao_Espero_Proxima_Data_Fechamento()
        {
            DateTime dataFechamento = DateTime.Now;

            var cartaoMock = new Mock<Cartao>();

            var dataRecebida = cartaoMock.Object.CalcularProximaDataFechamento(dataFechamento);

            Assert.Equal(dataFechamento.Date.Month + 1, dataRecebida.Month);
        }
    }
}
