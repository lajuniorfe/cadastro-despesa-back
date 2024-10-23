using System;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas.Interfaces;

public interface IDespesaApp
{
    IList<DespesaResponse> BuscarDespesas();
    public void CadastrarDespesa(DespesaRequest despesaRequest);
}
