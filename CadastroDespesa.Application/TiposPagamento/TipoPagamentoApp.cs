using AutoMapper;
using CadastroDespesa.Application.TiposPagamento.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using CadastroDespesa.DTO.TiposPagamento.Requests;
using CadastroDespesa.DTO.TiposPagamento.Responses;

namespace CadastroDespesa.Application.TiposPagamento
{
    public class TipoPagamentoApp : ITipoPagamentoApp
    {
        private readonly ITipoPagamentoRepositorio tipoPagamentoRepositorio;
        private readonly IMapper _mapper;
        public TipoPagamentoApp(ITipoPagamentoRepositorio tipoPagamentoRepositorio, IMapper mapper)
        {
            this.tipoPagamentoRepositorio = tipoPagamentoRepositorio;
            _mapper = mapper;
        }

        public async Task CriarTipoPagamento(TipoPagamentoRequest request)
        {
            TipoPagamento tipoPagamento = _mapper.Map<TipoPagamento>(request);
            await tipoPagamentoRepositorio.Criar(tipoPagamento);
        }

        public async Task<IList<TipoPagamentoResponse>> RetornarTiposPagamento()
        {
            IEnumerable<TipoPagamento> tiposPagamento = await tipoPagamentoRepositorio.ObterTodos();

            IList<TipoPagamentoResponse> response = _mapper.Map<IList<TipoPagamentoResponse>>(tiposPagamento);
            return response;
        }
    }
}
