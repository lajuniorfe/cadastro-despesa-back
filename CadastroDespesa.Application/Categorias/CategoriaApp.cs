using AutoMapper;
using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;

namespace CadastroDespesa.Application.Categorias
{
    public class CategoriaApp : ICategoriaApp
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaApp(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            this.categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<IList<CategoriaResponse>> BuscarCategorias()
        {
            IEnumerable<Categoria> retorno = await categoriaRepositorio.ObterTodos();

            return _mapper.Map<IList<CategoriaResponse>>(retorno);
        }

        public async Task CriarCategoria(CategoriaRequest request)
        {
            Categoria categoria = _mapper.Map<Categoria>(request);

            await categoriaRepositorio.Criar(categoria);

        }
    }
}
