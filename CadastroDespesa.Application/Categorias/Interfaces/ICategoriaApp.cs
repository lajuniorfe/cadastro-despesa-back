using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.Categorias.Interfaces
{
    public interface ICategoriaApp
    {
        Task<IList<CategoriaResponse>> BuscarCategorias();
        Task CriarCategoria(CategoriaRequest request);
        Task<CategoriaResponse> EditarCategoria(CategoriaRequest request, int id);
    }
}
