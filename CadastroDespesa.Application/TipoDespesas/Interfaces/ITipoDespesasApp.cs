using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TipoDespesas.Responses;

namespace CadastroDespesa.Application.TipoDespesas.Interfaces
{
    public interface ITipoDespesasApp
    {
        Task<IList<TipoDespesaResponse>> BuscarTipoDespesas();
        Task CadastrarTipoDespesa(TipoDespesaRequest request);
    }
}
