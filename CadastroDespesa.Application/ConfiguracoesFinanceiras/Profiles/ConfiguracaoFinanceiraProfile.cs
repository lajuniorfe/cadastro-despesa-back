using AutoMapper;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Requests;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Responses;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.ConfiguracoesFinanceiras.Profiles
{
    internal class ConfiguracaoFinanceiraProfile: Profile
    {
        public ConfiguracaoFinanceiraProfile()
        {
            CreateMap<ConfiguracaoFinanceira, ConfiguracaoFinanceiraResponse>();
            CreateMap<ConfiguracaoFinanceiraRequest, ConfiguracaoFinanceira>();
         

        }
    }
}
