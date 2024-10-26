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

        public void CriarTipoPagamento(TipoPagamentoRequest request)
        {
            TipoPagamento tipoPagamento = _mapper.Map<TipoPagamento>(request);
            tipoPagamentoRepositorio.Criar(tipoPagamento);
        }

        public IList<TipoPagamentoResponse> RetornarTiposPagamento()
        {
            IEnumerable<TipoPagamento> tiposPagamento = tipoPagamentoRepositorio.ObterTodos();

            IList<TipoPagamentoResponse> response = _mapper.Map<IList<TipoPagamentoResponse>>(tiposPagamento);
            return response;
        }
    }
}
