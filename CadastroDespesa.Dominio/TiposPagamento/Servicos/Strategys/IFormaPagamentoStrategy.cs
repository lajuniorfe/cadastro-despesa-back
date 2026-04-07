using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.commands;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys
{
    public interface IFormaPagamentoStrategy
    {
        Task ProcessarAsync(Despesa despesa, PagamentoCommand command);
    }
}
