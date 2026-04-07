using AutoMapper;
using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.DTO.Recorrencias.Requests;
using CadastroDespesa.DTO.Recorrencias.Responses;

namespace CadastroDespesa.Application.Recorrencias.Profiles
{
    public class RecorrenciaProfile : Profile
    {
        public RecorrenciaProfile()
        {
            CreateMap<Recorrencia, RecorrenciaResponse>();
            CreateMap<RecorrenciaRequest, Recorrencia>();
        }
    }
}
