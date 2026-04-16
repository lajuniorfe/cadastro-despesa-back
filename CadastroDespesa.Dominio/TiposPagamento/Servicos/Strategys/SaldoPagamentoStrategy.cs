using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Commands;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys
{
    public class SaldoPagamentoStrategy : IFormaPagamentoStrategy
    {
        public Task<IList<DespesaRelacionamento>> ProcessarAsync(PagamentoCommandBase command)
        {
            var comando = (PagamentoSaldoCommand)command;

            foreach (var i in comando.DespesasRelacionamento)
            {
                i.SetIdFatura(0);
            }

            return Task.FromResult(comando.DespesasRelacionamento);
        }
    }
}
