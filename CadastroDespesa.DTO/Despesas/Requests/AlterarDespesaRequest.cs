namespace CadastroDespesa.DTO.Despesas.Requests
{
    public class AlterarDespesaRequest
    {
        public int IdDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
        public DateTime DataDespesa {  get; set; }
        public string Descricao { get; set; }
        public int Parcela {  get; set; }
        public int IdCartao { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoPagamento { get; set; }
    }
}
