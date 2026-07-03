using CadastroDespesa.Application.Investimentos.Intefaces;
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
    }
}
