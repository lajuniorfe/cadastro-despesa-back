using AutoMapper;
using CadastroDespesa.Application.ResumosFinanceiros.Dtos.Responses;
using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Entidades;
using CadastroDespesa.DTO.Recorrencias.Requests;
using CadastroDespesa.DTO.Recorrencias.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.ResumosFinanceiros.Profiles
{
    public class ResumoFinanceiroProfile: Profile
    {
        public ResumoFinanceiroProfile()
        {
            CreateMap<ResumoFinanceiro, ResumoFinanceiroResponse>();
        }
    }
}
