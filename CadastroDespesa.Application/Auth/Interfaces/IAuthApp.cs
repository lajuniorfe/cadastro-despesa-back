using CadastroDespesa.DTO.Auths.Requests;

namespace CadastroDespesa.Application.Auth.Interfaces
{
    public interface IAuthApp
    {
        public Task<Dictionary<string, string>> Logar(AuthUsuarioRequest authUsuario);
    }
}
