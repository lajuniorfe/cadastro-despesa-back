using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.DTO.Despesas.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Despesas
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult CadastrarDespesa([FromBody] DespesaRequest despesa) {
            
            despesaApp.CadastrarDespesa(despesa);

            return Ok();
        }
    }
}
