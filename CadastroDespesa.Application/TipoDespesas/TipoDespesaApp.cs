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

        public IList<TipoDespesaResponse> BuscarTipoDespesas()
        {
            IEnumerable<TipoDespesa> tipoDespesas = tipoDespesaRepositorio.ObterTodos();
            return _mapper.Map<IList<TipoDespesaResponse>>(tipoDespesas);
        }

        public void CadastrarTipoDespesa(TipoDespesaRequest request)
        {
            TipoDespesa tipoDespesa = _mapper.Map<TipoDespesa>(request);

            tipoDespesaRepositorio.Criar(tipoDespesa);
        }
    }
}
