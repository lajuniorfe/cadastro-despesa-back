using CadastroDespesa.DTO.Usuarios.Requests;
using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.Application.Usuarios.Interfaces
{
    public interface IUsuarioApp
    {
        Task CadastrarUsuarioAsync(UsuarioRequest request);
        Task<UsuarioResponse> RetornarUsuarioIdAsync(int id);
        Task<IList<UsuarioResponse>> ListUsuariosAsync();

    }
}
