namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public abstract class DespesaCommandBase
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdDespesa { get; set; }


        protected DespesaCommandBase(DateTime data, decimal valor, int idDespesa)
        {
            Data = data;
            Valor = valor;
            IdDespesa = idDespesa;
        }
    }
}
