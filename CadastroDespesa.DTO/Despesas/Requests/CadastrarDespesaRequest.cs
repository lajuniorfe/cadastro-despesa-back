using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartoes.Requests;
using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.TipoDespesas.Requests;
using CadastroDespesa.DTO.TiposPagamento.Requests;

namespace CadastroDespesa.DTO.Despesas.Requests
{
    public class CadastrarDespesaRequest
    {
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public required CategoriaRequest Categoria { get; set; }
        public required TipoDespesaRequest TipoDespesa { get; set; }
        public required TipoPagamentoRequest TipoPagamento { get; set; }
        public CartaoRequest? Cartao { get; set; }
        public int? Parcela { get; set; }

    }
}
