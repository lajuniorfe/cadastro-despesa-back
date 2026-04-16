using CadastroDespesa.Application.Auth.Interfaces;
using CadastroDespesa.Dominio.Usuarios.Entidades;
using CadastroDespesa.Dominio.Usuarios.Repositorios;
using CadastroDespesa.DTO.Auths.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CadastroDespesa.Application.Auth
{
    public class AuthApp : IAuthApp
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IConfiguration _configuration;


        public AuthApp(IUsuarioRepositorio usuarioRepositorio, IConfiguration configuration)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, string>> Logar(AuthUsuarioRequest authUsuario)
        {
            var usuario = await usuarioRepositorio
         .Buscar(u => u.Login == authUsuario.Login && u.Senha == authUsuario.Senha);

            var usuarioEncontrado = usuario;

            if (usuarioEncontrado == null)
                throw new Exception("Usuario ou Senha incorreto");

            var token = new Dictionary<string, string>
            {
                {   "token", GerarToken(usuarioEncontrado, "usuario")}
            };

            return token;
        }


        private string GerarToken(Usuario usuario, string role)
        {
            var claims = new[]
            {
                new  Claim(JwtRegisteredClaimNames.Sub, usuario.Nome),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
