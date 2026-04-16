using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas.Interfaces;

public interface IDespesaApp
{
    Task<IList<DespesaResponse>> BuscarDespesas();
    Task<DespesaRelacionamentoResponse> CadastrarDespesa(CadastrarDespesaRequest despesaRequest);

    Task<IList<DespesaRelacionamentoResponse>> BuscarDespesasMesCorrespondente(int mes, int ano);
    Task<DespesaResponse> BuscarDespesasId(int id);
    Task ExcluirDespesa(int idDespesa);
}
