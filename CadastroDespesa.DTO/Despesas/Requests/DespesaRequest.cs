using System;

namespace CadastroDespesa.DTO.Despesas.Requests;

public class DespesaRequest
{
    public string? Descricao {get; set;}
    public decimal Valor {get;set;}
}
