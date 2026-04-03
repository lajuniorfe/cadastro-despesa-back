using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Strategys
{
    public interface IDespesaStrategy
    {
        IEnumerable<Despesa> Criar(DespesaCommand commmand);
    }
}
