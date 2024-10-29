using AutoMapper;
using CadastroDespesa.Application.TipoDespesas.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TipoDespesas.Responses;

namespace CadastroDespesa.Application.TipoDespesas
{
    public class TipoDespesaApp : ITipoDespesasApp
    {
        private readonly ITipoDespesaRepositorio tipoDespesaRepositorio;
        private readonly IMapper _mapper;

        public TipoDespesaApp(ITipoDespesaRepositorio tipoDespesaRepositorio, IMapper mapper)
        {
            this.tipoDespesaRepositorio = tipoDespesaRepositorio;
            _mapper = mapper;
        }

        public async Task<IList<TipoDespesaResponse>> BuscarTipoDespesas()
        {
            IEnumerable<TipoDespesa> response = await tipoDespesaRepositorio.ObterTodos();
            return _mapper.Map<IList<TipoDespesaResponse>>(response);
        }

        public async Task CadastrarTipoDespesa(TipoDespesaRequest request)
        {
            TipoDespesa tipoDespesa = _mapper.Map<TipoDespesa>(request);

            await tipoDespesaRepositorio.Criar(tipoDespesa);
        }
    }
}
