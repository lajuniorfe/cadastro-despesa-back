using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TransacoesDespesas.Entidades
{
    public class TransacaoDespesa : BaseEntidade
    {
        public virtual Despesa? Despesa { get; protected set; }
        public virtual DateTime Data { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual TipoPagamento? TipoPagamento { get; protected set; }
        public virtual bool StatusPagamento { get; protected set; }

        public TransacaoDespesa() { }
        public TransacaoDespesa(Despesa despesa, DateTime data, decimal valor, TipoPagamento tipoPagamento, bool statusPagamento)
        {
            Despesa = despesa;
            Data = data;
            Valor = valor;
            TipoPagamento = tipoPagamento;
            StatusPagamento = statusPagamento;
        }

        public virtual void SetDespesa(Despesa despesa)
        {
            Despesa = despesa;
        }

        public virtual void SetData(DateTime data) 
        { 
            Data = data; 
        }

        public virtual void SetValor(decimal valor)
        {
            Valor = valor;
        }

        public virtual void SetTipoPagamento(TipoPagamento tipoPagamento)
        {
            TipoPagamento = tipoPagamento;
        }

        public virtual void SetStatusPagamento(bool statusPagamento) 
        {
            StatusPagamento = statusPagamento;
        }
    }
}
