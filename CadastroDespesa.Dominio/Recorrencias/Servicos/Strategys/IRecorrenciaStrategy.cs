using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys
{
    public interface IRecorrenciaStrategy
    {
        IEnumerable<Despesa> Criar(DespesaCommand commmand);
    }
}
