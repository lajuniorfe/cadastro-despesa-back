using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.DTO.Despesas.Requests;
using Microsoft.AspNetCore.Authorization;
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

            return Ok(await despesaApp.CadastrarDespesa(despesa));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarDespesas()
        {
            return Ok(await despesaApp.BuscarDespesas());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarDespesasId(int id)
        {
            return Ok(await despesaApp.BuscarDespesasId(id));

        }

        [Authorize]
        [HttpGet("mes/{mes}/{ano}")]
        public async Task<IActionResult> BuscarDespesasMesCorrespondente(int mes, int ano)
        {
            return Ok(await despesaApp.BuscarDespesasMesCorrespondente(mes, ano));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BuscarDespesasMesCorrespondente(int id)
        {
            await despesaApp.ExcluirDespesa(id);

            return Ok();
        }
    }
}
