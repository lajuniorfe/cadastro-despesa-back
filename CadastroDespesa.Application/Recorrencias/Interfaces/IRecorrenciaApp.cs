using CadastroDespesa.DTO.Recorrencias.Requests;
using CadastroDespesa.DTO.Recorrencias.Responses;

namespace CadastroDespesa.Application.Recorrencias.Interfaces
{
    public interface IRecorrenciaApp
    {
        Task<IList<RecorrenciaResponse>> BuscarRecorrencias();
        Task CadastrarRecorrencia(RecorrenciaRequest request);
    }
}
