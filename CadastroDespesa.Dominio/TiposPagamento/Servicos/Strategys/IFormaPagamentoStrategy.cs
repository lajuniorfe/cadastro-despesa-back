using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Commands;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys
{
    public interface IFormaPagamentoStrategy
    {
        Task<IList<DespesaRelacionamento>> ProcessarAsync(PagamentoCommandBase command);
    }
}
