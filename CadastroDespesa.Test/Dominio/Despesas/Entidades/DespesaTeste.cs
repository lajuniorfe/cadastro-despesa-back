using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Despesas.Entidades
{
    public class DespesaTeste
    {
        [Fact]
        public void Quando_Instanciar_Despesa_Espero_Valores_Validos()
        {
            //arrange
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();
            var tipoDespesa = new Mock<TipoDespesa>();

            //act
            Despesa despesa = new(descricao, valor,data, categoria.Object, tipoDespesa.Object);

            //assert
            Assert.Equal(descricao, despesa.Descricao);
            Assert.Equal(valor, despesa.Valor);
            Assert.Equal(data, despesa.Data);
            Assert.Equal(categoria.Object, despesa.Categoria);
            Assert.Equal(tipoDespesa.Object, despesa.TipoDespesa);
        }
    }
}
