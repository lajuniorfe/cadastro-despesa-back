using AutoMapper;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Responses;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace CadastroDespesa.Application.ConfiguracoesFinanceiras
{
    public class ConfiguracaoFinanceiraApp : IConfiguracaoFinanceiraApp
    {
        private readonly IConfiguracaoFinanceiraRepositorio financeiraRepositorio;
        private readonly IMapper _mapper;

        public ConfiguracaoFinanceiraApp(IConfiguracaoFinanceiraRepositorio financeiraRepositorio, IMapper mapper)
        {
            this.financeiraRepositorio = financeiraRepositorio;
            _mapper = mapper;
        }

        public async Task<ConfiguracaoFinanceiraResponse> RetornarConfiguracaoFinanceira()
        {
            IEnumerable<ConfiguracaoFinanceira> retorno = await financeiraRepositorio.ListarComIncludes(null,
                q => q.Include(dr => dr.Usuario));

            return _mapper.Map<ConfiguracaoFinanceiraResponse>(retorno.First());
        }
    }
}
