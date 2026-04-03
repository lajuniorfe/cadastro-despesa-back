using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Strategys
{
    public class DespesaFixaStrategy : IDespesaStrategy
    {
        public IEnumerable<Despesa> Criar(DespesaCommand command)
        {
            var despesas = new List<Despesa>();

            for (int mes = command.Data.Month; mes <= 12; mes++)
            {
                var data = new DateTime(command.Data.Year, mes, command.Data.Day);

                var despesa = Despesa.CriarFixa(
                command.Descricao ?? "",
                command.Valor,
                data,
                command.IdCategoria,
                command.IdTipoDespesa);

                despesas.Add(despesa);
            }

            return despesas;
        }
    }
}
