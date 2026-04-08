using CadastroDespesa.Application.Auth.Interfaces;
using CadastroDespesa.DTO.Auths.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Auth
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApp authApp;

        public AuthController(IAuthApp authApp)
        {

            this.authApp = authApp;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthUsuarioRequest authUsuario)
        {
            var token = await authApp.Logar(authUsuario);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);

        }

    }
}
