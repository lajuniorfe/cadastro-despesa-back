using AutoMapper;
using CadastroDespesa.Dominio.Investimentos.Entidades;
using CadastroDespesa.DTO.Investimentos.Responses;

namespace CadastroDespesa.Application.Investimentos.Profiles
{
    public class InvestimentoProfile : Profile
    {
        public InvestimentoProfile()
        {
            CreateMap<Investimento, InvestimentoResponse>();
              
        }
    }
}
