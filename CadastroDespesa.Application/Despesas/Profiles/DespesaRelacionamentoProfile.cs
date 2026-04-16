using AutoMapper;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas.Profiles
{
    public class DespesaRelacionamentoProfile: Profile
    {
        public DespesaRelacionamentoProfile()
        {
            CreateMap<DespesaRelacionamento, DespesaRelacionamentoResponse>();
        }
          
    //CreateMap<DespesaRequest, DespesaRelacionamento>();
    //CreateMap<CadastrarDespesaRequest, DespesaRelacionamento>();
    }
}


