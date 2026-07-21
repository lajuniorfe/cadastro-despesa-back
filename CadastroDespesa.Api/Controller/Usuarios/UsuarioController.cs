using CadastroDespesa.Application.Usuarios.Interfaces;
using CadastroDespesa.DTO.Usuarios.Requests;
using CadastroDespesa.DTO.Usuarios.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioApp usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            this.usuarioApp = usuarioApp;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CadastrarUsuario([FromBody] UsuarioRequest request)
        {
            usuarioApp.CadastrarUsuarioAsync(request);

            return Created();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RetornarUsauarios()
        {
            IList<UsuarioResponse> response = await usuarioApp.ListUsuariosAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> RetornarUsauarioId(int id)
        {
            UsuarioResponse response = await usuarioApp.RetornarUsuarioIdAsync(id);

            return Ok(response);
        }

        [HttpGet("azure/{id}")]
        [Authorize]
        public async Task<IActionResult> RetornarUsauarioIdAzure(string id)
        {
            UsuarioResponse response = await usuarioApp.RetornarUsuarioIdAzureAsync(id);

            return Ok(response);
        }
    }
}
