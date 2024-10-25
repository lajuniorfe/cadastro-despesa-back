using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;

namespace CadastroDespesa.Application.Categorias.Interfaces
{
    public interface ICategoriaApp
    {
        IList<CategoriaResponse> BuscarCategorias();
        void CriarCategoria(CategoriaRequest request);
    }
}
