using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaFixaProcessar : ITipoDepesaProcessar
    {
        Task ProcessarTipoDespesaFixa(Despesa despesa, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao);
    }
}
