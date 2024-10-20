using System;

namespace CadastroDespesa.DTO.Despesas.Responses;

public class DespesaResponse
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime Data {get;set;}
    public decimal Valor {get; set;}
}
