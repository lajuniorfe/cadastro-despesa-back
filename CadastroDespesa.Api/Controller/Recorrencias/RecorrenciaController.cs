using CadastroDespesa.Application.Recorrencias.Interfaces;
using CadastroDespesa.DTO.Recorrencias.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Recorrencias
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecorrenciaController : ControllerBase
    {
        private readonly IRecorrenciaApp recorrenciaApp;

        public RecorrenciaController(IRecorrenciaApp recorrenciaApp)
        {
            this.recorrenciaApp = recorrenciaApp;
        }

        /// <summary>
        /// Busca recorrencias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BuscarTipoDespesas()
        {
            return Ok(await recorrenciaApp.BuscarRecorrencias());
        }

        /// <summary>
        /// Cadastrar uma recorrencia
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarTipoDespesa([FromBody] RecorrenciaRequest request)
        {
            await recorrenciaApp.CadastrarRecorrencia(request);

            return Ok();
        }
    }
}
