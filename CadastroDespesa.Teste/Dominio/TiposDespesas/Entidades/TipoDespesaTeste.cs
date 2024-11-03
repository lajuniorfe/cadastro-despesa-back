using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.TiposDespesas.Entidades
{
    public class TipoDespesaTeste
    {
        [Fact]
        public void Quando_Instanciar_TipoDespesa_Espero_TipoDespesa_Validos()
        {
            string nome = "Tipo Despesa Teste";
            string descricao = "Testar Tipo Despesa";

            TipoDespesa tipoDespesa = new TipoDespesa(nome, descricao);

            Assert.Equal(nome, tipoDespesa.Nome);
            Assert.Equal(descricao, tipoDespesa.Descricao);
        }

    }
}
