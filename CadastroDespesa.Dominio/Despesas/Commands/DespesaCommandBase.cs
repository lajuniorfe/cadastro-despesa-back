
namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public class DespesaCommandBase : DespesaCommand
    {
        public DespesaCommandBase(string? descricao, DateTime data, decimal valor, int idCategoria, int idTipoDespesa, int idUsuario) 
            : base(descricao, data, valor, idCategoria, idTipoDespesa, idUsuario)
        {
        }
    }
}
