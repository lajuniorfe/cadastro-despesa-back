using CadastroDespesa.Application.Categorias.Interfaces;
using CadastroDespesa.DTO.Categorias.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDespesa.Api.Controller.Categorias
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApp categoriaApp;

        public CategoriaController(ICategoriaApp categoriaApp)
        {
            this.categoriaApp = categoriaApp;
        }

        /// <summary>
        /// Cadastra uma Categoria
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarCategoria([FromBody] CategoriaRequest request)
        {
            categoriaApp.CriarCategoria(request);
            return Ok();
        }

        /// <summary>
        /// Buscar todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BuscarCategorias()
        {
            return Ok(categoriaApp.BuscarCategorias());
        }
    }
}
