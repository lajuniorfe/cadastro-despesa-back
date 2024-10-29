using AutoMapper;
using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;

namespace CadastroDespesa.Application.Categorias
{
    public class CategoriaApp : ICategoriaApp
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public CategoriaApp(ICategoriaRepositorio categoriaRepositorio, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<CategoriaResponse>> BuscarCategorias()
        {
            try
            {
                IEnumerable<Categoria> retorno = await categoriaRepositorio.ObterTodos();
                return _mapper.Map<IList<CategoriaResponse>>(retorno); ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CriarCategoria(CategoriaRequest request)
        {
            Categoria categoria = _mapper.Map<Categoria>(request);

            await categoriaRepositorio.Criar(categoria);

        }
    }
}
