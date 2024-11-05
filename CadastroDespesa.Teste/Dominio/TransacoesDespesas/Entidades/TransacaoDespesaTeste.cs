using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.TransacoesDespesas.Entidades
{
    public class TransacaoDespesaTeste
    {
        [Fact]
        public void Quando_Instanciar_TransacaoDespesa_Espero_Valores_Validos()
        {
            Despesa despesa = new Mock<Despesa>().Object;
            DateTime dataTransacao = DateTime.Now;
            decimal valor = 10m;
            TipoPagamento tipoPagamento = new Mock<TipoPagamento>().Object;
            bool statusPagamento = true;

            TransacaoDespesa transacaoDespesa = new(despesa, dataTransacao, valor, tipoPagamento, statusPagamento);

            Assert.Equal(despesa, transacaoDespesa.Despesa);
            Assert.Equal(dataTransacao, transacaoDespesa.Data);
            Assert.Equal(valor, transacaoDespesa.Valor);
            Assert.Equal(tipoPagamento, transacaoDespesa.TipoPagamento);
            Assert.Equal(statusPagamento, transacaoDespesa.StatusPagamento);
        }
    }
}
