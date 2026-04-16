using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Commands;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys
{
    public class RecorrenciaUnicaStrategy : IRecorrenciaStrategy
    {
        private readonly IFormaPagamentoFactory formaPagamentoFactory;

        public RecorrenciaUnicaStrategy(IFormaPagamentoFactory formaPagamentoFactory)
        {
            this.formaPagamentoFactory = formaPagamentoFactory;
        }

        public IEnumerable<DespesaRelacionamento> Criar(DespesaCommandBase command)
        {

            var lista = new List<DespesaRelacionamento>
            {
                DespesaRelacionamento.CriarSemParcela(command.IdDespesa, command.Valor, command.Data)
            };

            return lista;
        }
    }
}
