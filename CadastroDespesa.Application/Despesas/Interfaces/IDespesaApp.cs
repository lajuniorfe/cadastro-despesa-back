using System;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas.Interfaces;

public interface IDespesaApp
{
    Task<IList<DespesaResponse>> BuscarDespesas();
    Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest);
}
