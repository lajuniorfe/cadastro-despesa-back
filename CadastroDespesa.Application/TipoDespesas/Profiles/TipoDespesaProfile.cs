using AutoMapper;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TipoDespesas.Responses;

namespace CadastroDespesa.Application.TipoDespesas.Profiles
{
    public class TipoDespesaProfile : Profile
    {
        public TipoDespesaProfile()
        {
            CreateMap<TipoDespesa, TipoDespesaResponse>();
            CreateMap<TipoDespesaRequest, TipoDespesa>();
        }
    }
}
