using AutoMapper;
using CadastroDespesa.Application.Investimentos.Intefaces;
using CadastroDespesa.Dominio.Investimentos.Entidades;
using CadastroDespesa.Dominio.Investimentos.Repositorios;
using CadastroDespesa.DTO.Investimentos.Responses;

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

        public async Task<IList<InvestimentoResponse>> RetornarListaInvestimentos()
        {
            IEnumerable<Investimento> response = await investimentoRepositorio.ListarComIncludes(i => i.Usuario);
            return _mapper.Map<IList<InvestimentoResponse>>(response);
        }
    }
}
