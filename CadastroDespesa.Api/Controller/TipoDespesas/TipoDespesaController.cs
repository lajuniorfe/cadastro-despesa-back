using CadastroDespesa.Application.TipoDespesas.Interfaces;
using CadastroDespesa.DTO.TipoDespesas.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.TipoDespesas
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDespesaController : ControllerBase
    {
        private readonly ITipoDespesasApp tipoDespesaApp;

        public TipoDespesaController(ITipoDespesasApp tipoDespesaApp)
        {
            this.tipoDespesaApp = tipoDespesaApp;
        }

        /// <summary>
        /// Busca Tipos de Despesas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BuscarTipoDespesas()
        {
           return Ok( tipoDespesaApp.BuscarTipoDespesas());
        }

        /// <summary>
        /// Cadastrar um Tipo de Despesa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarTipoDespesa([FromBody] TipoDespesaRequest request)
        {
            tipoDespesaApp.CadastrarTipoDespesa(request);

            return Ok();
        }
    }
}
