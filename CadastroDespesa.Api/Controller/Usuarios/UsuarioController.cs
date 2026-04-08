using CadastroDespesa.Application.Usuarios.Interfaces;
using CadastroDespesa.DTO.Usuarios.Requests;
using CadastroDespesa.DTO.Usuarios.Responses;
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
        public IActionResult CadastrarUsuario([FromBody] UsuarioRequest request)
        {
            usuarioApp.CadastrarUsuarioAsync(request);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> RetornarUsauarios()
        {
            IList<UsuarioResponse> response = await usuarioApp.ListUsuariosAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarUsauarioId(int id)
        {
            UsuarioResponse response = await usuarioApp.RetornarUsuarioIdAsync(id);

            return Ok(response);
        }
    }
}
