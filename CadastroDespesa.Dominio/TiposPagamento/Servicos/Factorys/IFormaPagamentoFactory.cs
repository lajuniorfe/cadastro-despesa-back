using CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys
{
    public interface IFormaPagamentoFactory
    {
        IFormaPagamentoStrategy Obter(int idTipoPagamento);
    }
}
