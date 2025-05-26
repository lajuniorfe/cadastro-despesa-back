using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Cartoes.Servicos
{
    public class CartaoServico : ICartaoServico
    {
        private readonly ICartaoRepositorio cartaoRepositorio;

        public CartaoServico(ICartaoRepositorio cartaoRepositorio)
        {
            this.cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<Cartao> BuscarCartaoNomeAsync(string cartao)
        {
            Cartao response = await cartaoRepositorio.Buscar(c => c.Nome == cartao);
            return response;
        }

        public async Task<Cartao> ValidarCartaoAsync(int idCartao)
        {
            Cartao retorno = await cartaoRepositorio.ObterPorId(idCartao);

            return retorno;
        }
    }
}
