using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos.Strategys
{
    public class TipoDespesaParceladaStrategy : ITipoDespesaStrategy
    {
        public IEnumerable<Despesa> Criar(DespesaCommand command)
        {
            var parceladaCommand = (DespesaParceladaCommand)command;

            return Despesa.CriarParcelada(
             parceladaCommand.Descricao ?? "",
             parceladaCommand.Valor,
             parceladaCommand.Data,
             parceladaCommand.IdCategoria,
             parceladaCommand.IdTipoDespesa,
             parceladaCommand.Parcela);
        }
    }
}
