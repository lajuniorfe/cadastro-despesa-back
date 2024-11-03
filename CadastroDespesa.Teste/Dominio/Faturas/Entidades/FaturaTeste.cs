using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Faturas.Entidades
{
    public class FaturaTeste
    {
        [Fact]
        public void Quando_Instancia_Fatura_Espero_Valores_Validos()
        {
            decimal valor = 10;
            DateTime dataVencimento = DateTime.Now;
            DateTime MesCorrespondente = DateTime.Now;
            Cartao cartaoValidoMock = new Mock<Cartao>().Object;

            Fatura fatura = new(valor, dataVencimento.Date, MesCorrespondente.Date, cartaoValidoMock);

            Assert.Equal(valor, fatura.Valor);
            Assert.Equal(dataVencimento.Date, fatura.DataVencimento);
            Assert.Equal(MesCorrespondente.Date, fatura.MesCorrespondente.Date);
            Assert.Equal(cartaoValidoMock, fatura.Cartao);
        }
    }
}
