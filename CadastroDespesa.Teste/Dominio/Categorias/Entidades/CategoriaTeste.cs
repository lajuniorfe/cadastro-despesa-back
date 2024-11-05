using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Categorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Categorias.Entidades
{
    public class CategoriaTeste
    {
        [Fact]
        public void Quando_Instanciar_Categoria_Espero_Valores_Validos()
        {
            string nome = "Categoria teste";
          

            Categoria categoria = new(nome);

            Assert.Equal(nome, categoria.Nome);
        }
    }
}
