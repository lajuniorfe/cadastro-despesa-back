namespace CadastroDespesa.DTO.Despesas.Requests
{
    public class CadastrarDespesaRequest
    {
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public int idRecorrencia { get; set; }
        public int IdTipoPagamento { get; set; }
        public int? IdCartao { get; set; }
        public int? Parcela { get; set; }

    }
}
