namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public abstract class DespesaCommand
    {
        protected DespesaCommand(string? descricao, DateTime data, decimal valor,  int idCategoria, int idTipoDespesa, int idUsuario)
        {
            Descricao = descricao;
            Data = data;
            Valor = valor;
            IdCategoria = idCategoria;
            IdTipoDespesa = idTipoDespesa;
            IdUsuario = idUsuario;
        }

        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public  int IdCategoria { get;  set; }
        public  int IdTipoDespesa { get;  set; }
        public  int IdUsuario { get;  set; }
    }
}
