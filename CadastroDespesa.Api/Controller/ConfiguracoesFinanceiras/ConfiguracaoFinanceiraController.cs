using CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.ConfiguracoesFinanceiras
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracaoFinanceiraController : ControllerBase
    {
        private readonly IConfiguracaoFinanceiraApp configuracaoFinanceiraApp;

        public ConfiguracaoFinanceiraController(IConfiguracaoFinanceiraApp configuracaoFinanceiraApp)
        {
            this.configuracaoFinanceiraApp = configuracaoFinanceiraApp;
        }

        [HttpGet]
        public async Task<IActionResult> RetornarConfiguracaoFinanceira()
        {
            return Ok(await configuracaoFinanceiraApp.RetornarConfiguracaoFinanceira());
        }
    }
}
