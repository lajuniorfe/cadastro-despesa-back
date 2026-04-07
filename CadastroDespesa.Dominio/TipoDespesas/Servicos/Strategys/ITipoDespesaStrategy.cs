using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos.Strategys
{
    public interface ITipoDespesaStrategy
    {
        IEnumerable<Despesa> Criar(DespesaCommand commmand);
    }
}
