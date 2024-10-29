using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;

namespace CadastroDespesa.Application.Categorias.Interfaces
{
    public interface ICategoriaApp
    {
        Task<IList<CategoriaResponse>> BuscarCategorias();
        Task CriarCategoria(CategoriaRequest request);
    }
}
