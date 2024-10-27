using CadastroDespesa.DTO.Cartoes.Requests;
using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TiposPagamento.Requests;

namespace CadastroDespesa.DTO.Despesas.Requests;

public class DespesaRequest
{
    public string? Descricao {get; set;}
    public decimal Valor {get;set;}
    public CategoriaRequest Categoria {get; set;}
    public TipoPagamentoRequest TipoPagamento { get; set;}
    public TipoDespesaRequest TipoDespesa { get; set;}
    public CartaoRequest? Cartao { get; set;}
    public int Parcela {get; set;}
}
