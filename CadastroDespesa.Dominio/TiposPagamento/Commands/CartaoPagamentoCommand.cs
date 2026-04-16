using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.TiposPagamento.Commands
{
    public class CartaoPagamentoCommand: PagamentoCommandBase
    {
        public int IdCartao { get; }
   
        public CartaoPagamentoCommand(int idCartao, DateTime data, IList<DespesaRelacionamento> despesasRelacionamento) : base(data, despesasRelacionamento)
        {
            IdCartao = idCartao;
            this.DespesasRelacionamento = DespesasRelacionamento;
        }
    }
}
