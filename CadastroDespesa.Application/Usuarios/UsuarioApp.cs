using AutoMapper;
using CadastroDespesa.Application.Usuarios.Interfaces;
using CadastroDespesa.Dominio.Usuarios.Entidades;
using CadastroDespesa.Dominio.Usuarios.Repositorios;
using CadastroDespesa.DTO.Usuarios.Requests;
using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.Application.Usuarios
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IMapper _mapper;


        public UsuarioApp(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task CadastrarUsuarioAsync(UsuarioRequest request)
        {
            Usuario usuario = _mapper.Map<Usuario>(request);

            await usuarioRepositorio.Criar(usuario);
        }

        public async Task<IList<UsuarioResponse>> ListUsuariosAsync()
        {

            IEnumerable<Usuario> usuarios = await usuarioRepositorio.ObterTodos();

            IList<UsuarioResponse> response = _mapper.Map<IList<UsuarioResponse>>(usuarios.ToList());

            return response;
        }

        public async Task<UsuarioResponse> RetornarUsuarioIdAsync(int id)
        {
            Usuario usuario = await usuarioRepositorio.ObterPorId(id);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuario);

            return response;
        }
    }
}
