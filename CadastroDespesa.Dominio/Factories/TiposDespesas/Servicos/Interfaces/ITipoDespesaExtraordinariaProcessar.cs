using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaExtraordinariaProcessar : ITipoDepesaProcessar
    {
        Task ProcessarTipoDespesaExtraordinaria(Despesa despesa, TipoPagamento tipoPagamento, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao);
    }
}
