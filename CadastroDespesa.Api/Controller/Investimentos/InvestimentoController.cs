using CadastroDespesa.Application.Investimentos.Intefaces;
using CadastroDespesa.DTO.Investimentos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Investimentos
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoApp investimentoApp;
        public InvestimentoController(IInvestimentoApp investimentoApp)
        {
            this.investimentoApp = investimentoApp;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarInvestimentos()
        {
            return Ok(await investimentoApp.RetornarListaInvestimentos());
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarInvestimento([FromBody] InvestimentoRequest request)
        {
            await investimentoApp.CadastrarInvestimento(request);
            return Created();
        }
    }
}
