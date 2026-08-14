using AutoMapper;
using CadastroDespesa.Application.Investimentos.Intefaces;
using CadastroDespesa.Dominio.Investimentos.Entidades;
using CadastroDespesa.Dominio.Investimentos.Enums;
using CadastroDespesa.Dominio.Investimentos.Repositorios;
using CadastroDespesa.DTO.Investimentos.Requests;
using CadastroDespesa.DTO.Investimentos.Responses;
using Microsoft.EntityFrameworkCore;

namespace CadastroDespesa.Application.Investimentos
{
    public class InvestimentoApp : IInvestimentoApp
    {
        private readonly IInvestimentoRepositorio investimentoRepositorio;
        private readonly IMapper _mapper;


        public InvestimentoApp(IInvestimentoRepositorio investimentoRepositorio, IMapper mapper)
        {
            this.investimentoRepositorio = investimentoRepositorio;
            _mapper = mapper;
        }

        public async Task CadastrarInvestimento(InvestimentoRequest request)
        {
            Investimento investimento = new(request.Valor, request.Descricao, (TipoInvestimentoEnum)request.Tipo, request.Data, request.IdUsuario);
            
            if(investimento.Tipo == TipoInvestimentoEnum.Retirada || investimento.Tipo == TipoInvestimentoEnum.PagamentoDivida)
            {
                await investimentoRepositorio.Criar(investimento);
            }
            else
            {
                //alterar apenas o valor
            }
            
        }

        public async Task<IList<InvestimentoResponse>> RetornarListaInvestimentos()
        {
            IEnumerable<Investimento> response = await investimentoRepositorio.ListarComIncludes( null, d=> d.Include(d => d.Usuario));
            return _mapper.Map<IList<InvestimentoResponse>>(response);
        }
    }
}
