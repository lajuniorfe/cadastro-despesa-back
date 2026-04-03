namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public abstract class DespesaCommand
    {
        protected DespesaCommand(string? descricao, DateTime data, decimal valor,  int idCategoria, int idTipoDespesa)
        {
            Descricao = descricao;
            Data = data;
            Valor = valor;
            IdCategoria = idCategoria;
            IdTipoDespesa = idTipoDespesa;
        }

        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public virtual int IdCategoria { get; protected set; }
        public virtual int IdTipoDespesa { get; protected set; }
    }
}
