using AutoMapper;
using CadastroDespesa.Application.Recorrencias.Interfaces;
using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Repositorios;
using CadastroDespesa.DTO.Recorrencias.Requests;
using CadastroDespesa.DTO.Recorrencias.Responses;

namespace CadastroDespesa.Application.Recorrencias
{
    public class RecorrenciaApp : IRecorrenciaApp
    {
        private readonly IRecorrenciaRepositorio recorrenciaRepositorio;
        private readonly IMapper _mapper;

        public RecorrenciaApp(IRecorrenciaRepositorio recorrenciaRepositorio, IMapper mapper)
        {
            this.recorrenciaRepositorio = recorrenciaRepositorio;
            _mapper = mapper;
        }

        public async Task<IList<RecorrenciaResponse>> BuscarRecorrencias()
        {
            IEnumerable<Recorrencia> response = await recorrenciaRepositorio.ObterTodos();
            return _mapper.Map<IList<RecorrenciaResponse>>(response);
        }

        public async Task CadastrarRecorrencia(RecorrenciaRequest request)
        {
            Recorrencia recorrencia = _mapper.Map<Recorrencia>(request);

            await recorrenciaRepositorio.Criar(recorrencia);
        }
    }
}
