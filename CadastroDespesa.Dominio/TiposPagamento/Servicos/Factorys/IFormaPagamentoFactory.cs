using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys
{
    public interface IFormaPagamentoFactory
    {
        IFormaPagamentoStrategy Obter(int idTipoPagamento);
    }
}
