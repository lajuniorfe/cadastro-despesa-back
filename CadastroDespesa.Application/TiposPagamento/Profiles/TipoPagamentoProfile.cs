using AutoMapper;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.DTO.TiposPagamento.Requests;
using CadastroDespesa.DTO.TiposPagamento.Responses;

namespace CadastroDespesa.Application.TiposPagamento.Profiles
{
    public class TipoPagamentoProfile : Profile
    {
        public TipoPagamentoProfile()
        {
            CreateMap<TipoPagamento, TipoPagamentoResponse>();
            CreateMap<TipoPagamentoRequest, TipoPagamento>();
        }
    }
}
