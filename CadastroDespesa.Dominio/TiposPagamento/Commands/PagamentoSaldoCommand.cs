
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.TiposPagamento.Commands
{
    public class PagamentoSaldoCommand : PagamentoCommandBase
    {
        public PagamentoSaldoCommand(DateTime data, IList<DespesaRelacionamento> despesasRelacionamento) : base(data, despesasRelacionamento)
        {
        }
    }
}
