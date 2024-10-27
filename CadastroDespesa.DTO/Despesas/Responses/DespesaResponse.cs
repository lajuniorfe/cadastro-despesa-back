using CadastroDespesa.DTO.Categorias.Responses;
using CadastroDespesa.DTO.TipoDespesas.Responses;
using CadastroDespesa.DTO.TiposPagamento.Responses;
using System;

namespace CadastroDespesa.DTO.Despesas.Responses;

public class DespesaResponse
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public bool StatusPagamento { get; set; }
    public CategoriaResponse Categoria { get; set; }
    public TipoDespesaResponse TipoDespesa { get; set; }
    public TipoPagamentoResponse TipoPagamento { get; set; }
}
