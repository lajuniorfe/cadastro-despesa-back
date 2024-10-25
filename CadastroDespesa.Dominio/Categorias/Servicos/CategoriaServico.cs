using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Categorias.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Categoria> ValidarCategoriaAsync(int id)
        {
            Categoria response = await categoriaRepositorio.ObterPorId(id);

            return response;
        }
    }
}
