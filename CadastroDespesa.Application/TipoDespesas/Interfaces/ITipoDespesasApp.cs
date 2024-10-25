using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TipoDespesas.Responses;

namespace CadastroDespesa.Application.TipoDespesas.Interfaces
{
    public interface ITipoDespesasApp
    {
        IList<TipoDespesaResponse> BuscarTipoDespesas();
        void CadastrarTipoDespesa(TipoDespesaRequest request);
    }
}
