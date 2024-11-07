using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Parcelas.Entidades
{
    public class ParcelaTeste
    {
        [Fact]
        public void Quando_Instanciar_Pacela_Espero_Valores_Validos()
        {
            var despesa = new Mock<Despesa>();
            decimal valor = 10m;
            int numeroParcela = 2;
            DateTime data = DateTime.Now;
            var fatura = new Mock<Fatura>();

            Parcela parcela = new Parcela(despesa.Object, valor, numeroParcela, data, fatura.Object);

            Assert.Equal(despesa.Object, parcela.Despesa);
            Assert.Equal(valor, parcela.Valor);
            Assert.Equal(numeroParcela, parcela.NumeroParcela);
            Assert.Equal(data, parcela.Data);
            Assert.Equal(fatura.Object, parcela.Fatura);
        }

        [Fact]
        public void Quando_Calcular_Datas_Parcelas_Espero_Lista_De_Parcelas_Validas()
        {
            int totalParcelas = 2;
            var despesaMock = new Mock<Despesa>();

            var listaParcelas = Parcela.CalcularDataParcela(totalParcelas, despesaMock.Object);

            Assert.NotNull(listaParcelas);
            Assert.NotEmpty(listaParcelas);
        }
    }
}
