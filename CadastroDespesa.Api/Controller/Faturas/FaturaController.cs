using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Application.Faturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CadastroDespesa.Api.Controller.Faturas
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaturaController : ControllerBase
    {
        private readonly IFaturaApp faturasApp;

        public FaturaController(IFaturaApp faturasApp)
        {
            this.faturasApp = faturasApp;
        }

        [HttpGet("{cartao}/{mes}")]
        public async Task<IActionResult> BuscarFaturasCartaoMesCorrespondente(int cartao, int mes)
        {
            return Ok( await faturasApp.BuscarFaturasCartaoMesCorrespondente(mes, cartao));
        }

        [HttpGet("{mes}")]
        public async Task<IActionResult> BuscarFaturasMesCorrespondente( int mes)
        {
            return Ok(await faturasApp.BuscarFaturasMesCorrespondente(mes));
        }
    }
}
