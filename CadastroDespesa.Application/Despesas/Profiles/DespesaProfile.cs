using System;
using AutoMapper;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas.Profiles;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<Despesa, DespesaResponse>();
        CreateMap<DespesaRequest, Despesa>();
        CreateMap<CadastrarDespesaRequest, Despesa>();
            
    }
}
