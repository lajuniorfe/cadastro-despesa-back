using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys
{
    public class RecorrenciaFixaStrategy : IRecorrenciaStrategy
    {
        public IEnumerable<DespesaRelacionamento> Criar(DespesaCommandBase command)
        {
            var comando = (DespesaFixaCommand)command;

            IList<DespesaRelacionamento> despesaRelacionamento = DespesaRelacionamento.CriarFixa(comando.IdDespesa, comando.Valor, comando.Data);

            return despesaRelacionamento;
           
        }
    }
}
