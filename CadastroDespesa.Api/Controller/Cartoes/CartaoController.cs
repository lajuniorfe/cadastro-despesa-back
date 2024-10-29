using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Cartoes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartaoController : ControllerBase
    {
        private readonly ICartaoApp cartaoApp;

        public CartaoController(ICartaoApp cartaoApp)
        {
            this.cartaoApp = cartaoApp;
        }


        /// <summary>
        /// Cadastra um Cartão 
        /// </summary>
        /// <param name="cartao"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarDespesa([FromBody] CadastrarCartaoRequest request)
        {

            await cartaoApp.CadastrarCartao(request);

            return Ok();
        }

        /// <summary>
        /// Retorna todos os cartões
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BuscarDespesas()
        {
            return Ok(await cartaoApp.BuscarCartoes());
        }

        /// <summary>
        /// Retorna um cartão 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCartaoPorId(int id)
        {
            CartaoResponse response = await cartaoApp.BuscarCartao(id);

            if (response is null)
                return BadRequest();

            return Ok(response);
        }
    }
}
