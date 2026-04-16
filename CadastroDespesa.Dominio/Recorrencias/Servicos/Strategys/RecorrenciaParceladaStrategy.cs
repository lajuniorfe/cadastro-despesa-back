using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys
{
    public class RecorrenciaParceladaStrategy : IRecorrenciaStrategy
    {
        public IEnumerable<DespesaRelacionamento> Criar(DespesaCommandBase command)
        {
            var comando = (DespesaParceladaCommand)command;

            IList<DespesaRelacionamento> despesaRelacionamento = DespesaRelacionamento
                .CriarParcelada(comando.IdDespesa, comando.Valor, comando.Data, comando.Parcela);

            return despesaRelacionamento;
        }

    }
}

