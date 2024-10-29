using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.DTO.Despesas.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Despesas
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaApp despesaApp;

        public DespesaController(IDespesaApp despesaApp)
        {
            this.despesaApp = despesaApp;
        }

        /// <summary>
        /// Cadastra uma Despesa 
        /// </summary>
        /// <param name="despesa"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarDespesa([FromBody] CadastrarDespesaRequest despesa)
        {

            await despesaApp.CadastrarDespesa(despesa);

            return Ok();
        }

        [HttpGet]
        public IActionResult BuscarDespesas()
        {
            return Ok(despesaApp.BuscarDespesas());

        }
    }
}
