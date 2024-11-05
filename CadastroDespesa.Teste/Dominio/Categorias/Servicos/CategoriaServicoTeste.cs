using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Dominio.Categorias.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Categorias.Servicos
{
    public class CategoriaServicoTeste
    {
        private readonly Mock<ICategoriaRepositorio> _categoriaRepositorioMock;
        private readonly CategoriaServico _categoriaServico;

        public CategoriaServicoTeste()
        {
            _categoriaRepositorioMock = new Mock<ICategoriaRepositorio>();
            _categoriaServico = new CategoriaServico(_categoriaRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_Categoria_Espero_Retornar_Categoria_Valida()
        {
            int idCategoria = 1;
            var categoriaValida = new Mock<Categoria>();
            _categoriaRepositorioMock.Setup(r => r.ObterPorId(idCategoria))
                .ReturnsAsync(categoriaValida.Object);

            var categoriaRetornada = await _categoriaServico.ValidarCategoriaAsync(idCategoria);

            Assert.NotNull(categoriaRetornada);
        }
    }
}
