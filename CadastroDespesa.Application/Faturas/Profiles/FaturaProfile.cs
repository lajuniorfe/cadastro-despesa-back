using AutoMapper;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.DTO.Faturas.Responses;

namespace CadastroDespesa.Application.Faturas.Profiles
{
    public class FaturaProfile: Profile
    {
        public FaturaProfile()
        {
            CreateMap<Fatura, FaturaResponse>();
            //CreateMap<DespesaRequest, Despesa>();
            //CreateMap<CadastrarDespesaRequest, Despesa>();

        }
    }
}
