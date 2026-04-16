using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.TiposPagamento.Commands
{
    public abstract class PagamentoCommandBase
    {
        public DateTime Data { get; set; }
        public IList<DespesaRelacionamento> DespesasRelacionamento { get; set; }


        protected PagamentoCommandBase(DateTime data, IList<DespesaRelacionamento> despesasRelacionamento)
        {
            Data = data;
            DespesasRelacionamento = despesasRelacionamento;
        }


    }
}


