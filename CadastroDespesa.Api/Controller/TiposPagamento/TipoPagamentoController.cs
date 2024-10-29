using CadastroDespesa.Application.TiposPagamento.Interfaces;
using CadastroDespesa.DTO.TiposPagamento.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.TiposPagamento
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly ITipoPagamentoApp tipoPagamentoApp;

        public TipoPagamentoController(ITipoPagamentoApp tipoPagamentoApp)
        {
            this.tipoPagamentoApp = tipoPagamentoApp;
        }

        /// <summary>
        /// Busca Tipos de Pagamento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BuscarTipoPagamento()
        {
            return Ok(await tipoPagamentoApp.RetornarTiposPagamento());
        }

        /// <summary>
        /// Cadastrar um Tipo de Pagamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarTipoPagamento([FromBody] TipoPagamentoRequest request)
        {
            await tipoPagamentoApp.CriarTipoPagamento(request);

            return Ok();
        }
    }
}
