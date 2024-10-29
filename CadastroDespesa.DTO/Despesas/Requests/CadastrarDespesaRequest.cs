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
        public int IdCategoria { get; set; }
        public int IdTipoDespesa { get; set; }
        public int IdTipoPagamento { get; set; }
        public int IdCartao { get; set; }
        public int? Parcela { get; set; }

    }
}
