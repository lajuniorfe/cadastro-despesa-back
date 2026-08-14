using AutoMapper;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces;
using CadastroDespesa.Application.ResumosFinanceiros.Dtos.Responses;
using CadastroDespesa.Application.ResumosFinanceiros.Interfaces;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Repositorios;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.ResumosFinanceiro.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDespesa.Application.ResumosFinanceiros
{
    public class ResumoFinanceiroApp : IResumoFinanceiroApp
    {
        private readonly IResumoFinanceiroServico _resumoFinanceiroServico;
        private readonly IConfiguracaoFinanceiraRepositorio configuracaoFinanceiraRepositorio;
        private readonly IDespesaRepositorio despesaRepositorio;
        private readonly IMapper _mapper;


        public ResumoFinanceiroApp(IResumoFinanceiroServico resumoFinanceiroServico, IDespesaRepositorio despesaRepositorio, IMapper mapper, IConfiguracaoFinanceiraRepositorio configuracaoFinanceiraRepositorio)
        {
            _resumoFinanceiroServico = resumoFinanceiroServico;
            this.despesaRepositorio = despesaRepositorio;
            _mapper = mapper;
            this.configuracaoFinanceiraRepositorio = configuracaoFinanceiraRepositorio;
        }

        public async Task<ResumoFinanceiroResponse> RetornarResumoFinanceiroMes()
        {
            IEnumerable<Despesa> despesasRetornada = await despesaRepositorio.ListarComIncludes(d => d.Data.Month == DateTime.Now.Month
            && d.Data.Year == DateTime.Now.Year,
            d => d.Include(d => d.Categoria));
          
            var configuracao = await configuracaoFinanceiraRepositorio.ObterTodos();

            var tt = _resumoFinanceiroServico.Calcular(configuracao.First(), despesasRetornada);
            return _mapper.Map<ResumoFinanceiroResponse>(tt);
        }
    }
}
