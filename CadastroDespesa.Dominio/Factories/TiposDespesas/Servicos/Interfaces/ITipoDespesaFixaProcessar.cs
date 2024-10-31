using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaFixaProcessar : ITipoDepesaProcessar
    {
        Task<int> ProcessarTipoDespesaFixa(Despesa despesa, int idTipoDespesa);
    }
}
