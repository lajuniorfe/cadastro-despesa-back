using System;
using CadastroDespesa.DTO.Despesas.Requests;

namespace CadastroDespesa.Application.Despesas.Interfaces;

public interface IDespesaApp
{
    public void CadastrarDespesa(DespesaRequest despesaRequest);
}
