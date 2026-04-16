
namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public class DespesaFixaCommand : DespesaCommandBase
    {
        public DespesaFixaCommand( DateTime data, decimal valor, int idDespesa) 
            : base( data, valor, idDespesa)
        {
        }
    }
}
