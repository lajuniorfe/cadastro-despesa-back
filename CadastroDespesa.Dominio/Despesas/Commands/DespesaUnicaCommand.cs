using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public class DespesaUnicaCommand : DespesaCommandBase
    {
        public DespesaUnicaCommand(DateTime data, decimal valor, int idDespesa) : base(data, valor, idDespesa)
        {
        }
    }
}
