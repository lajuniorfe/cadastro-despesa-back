using AutoMapper;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;

namespace CadastroDespesa.Application.Cartoes
{
    public class CartaoApp : ICartaoApp
    {
        private readonly ICartaoRepositorio cartaoRepositorio;
        private readonly IMapper _mapper;
        private readonly ICartaoServico cartaoServico;


        public CartaoApp(ICartaoRepositorio cartaoRepositorio, IMapper mapper, ICartaoServico cartaoServico)
        {
            this.cartaoRepositorio = cartaoRepositorio;
            _mapper = mapper;
            this.cartaoServico = cartaoServico;
        }

        public async Task<CartaoResponse> AlterarCartao(CadastrarCartaoRequest request)
        {
            Cartao cartao = _mapper.Map<Cartao>(request);
            await cartaoRepositorio.Alterar(cartao);
            return _mapper.Map<CartaoResponse>(cartao);
        }

        public async Task<CartaoResponse> BuscarCartao(int id)
        {
            Cartao response = await cartaoRepositorio.ObterPorId(id);
            return _mapper.Map<CartaoResponse>(response);
        }

        public async Task<IList<CartaoResponse>> BuscarCartoes()
        {
            IEnumerable<Cartao> cartao = await cartaoRepositorio.ObterTodos();
            IList<CartaoResponse> response = _mapper.Map<IList<CartaoResponse>>(cartao);
            return response;
        }

        public async Task CadastrarCartao(CadastrarCartaoRequest request)
        {
            Cartao cartao = _mapper.Map<Cartao>(request);
            await cartaoRepositorio.Criar(cartao);
        }

        public async Task ExcluirCartao(int id)
        {
            Cartao retorno = await cartaoServico.ValidarCartaoAsync(id);
            await cartaoRepositorio.Deletar(retorno);
        }
    }
}
