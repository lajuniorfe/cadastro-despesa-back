using CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces;
using CadastroDespesa.Application.ResumosFinanceiros.Dtos.Responses;
using CadastroDespesa.Application.ResumosFinanceiros.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.ResumosFinanceiros
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumoFinanceiroController : ControllerBase
    {
        private readonly IResumoFinanceiroApp resumoFinanceiroApp;

        public ResumoFinanceiroController(IResumoFinanceiroApp resumoFinanceiroApp)
        {
            this.resumoFinanceiroApp = resumoFinanceiroApp;
        }

        [HttpGet]
        public async Task<IActionResult> RetornarResumoFinanceiro()
        {
            return Ok(await resumoFinanceiroApp.RetornarResumoFinanceiroMes());
        }
    }
}
