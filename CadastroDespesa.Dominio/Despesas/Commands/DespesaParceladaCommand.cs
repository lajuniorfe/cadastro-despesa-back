namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public class DespesaParceladaCommand : DespesaCommandBase
    {
        public int Parcela { get; set; }

        public DespesaParceladaCommand(int parcela, DateTime data, decimal valor, int idDespesa) : base(data, valor, idDespesa)
        {
            Parcela = parcela;
        }


    }
}
