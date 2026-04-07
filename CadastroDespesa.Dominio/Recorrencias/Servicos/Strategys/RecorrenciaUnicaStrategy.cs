using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys
{
    public class RecorrenciaUnicaStrategy : IRecorrenciaStrategy
    {
        public IEnumerable<Despesa> Criar(DespesaCommand command)
        {

            var baseCommand = (DespesaCommandBase)command;

            return new List<Despesa>
            {
                Despesa.CriarSemParcela(
                    baseCommand.Descricao ?? "",
                    baseCommand.Valor,
                    baseCommand.Data,
                    baseCommand.IdCategoria,
                    baseCommand.IdTipoDespesa
                )
            };
        }
    }
}
