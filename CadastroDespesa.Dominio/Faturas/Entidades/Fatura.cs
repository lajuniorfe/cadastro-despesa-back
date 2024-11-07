using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Faturas.Entidades
{
    public class Fatura : BaseEntidade
    {
        public virtual decimal Valor { get; protected set; }
        public virtual DateTime DataVencimento { get; protected set; }
        public virtual DateTime MesCorrespondente { get; protected set; }
        public virtual Cartao? Cartao { get; protected set; }

        public Fatura() { }
        public Fatura(decimal valor, DateTime dataVencimento, DateTime mesCorrespondente, Cartao cartao)
        {
            SetValor(valor);
            SetDataVencimento(dataVencimento);
            SetMesCorrespondente(mesCorrespondente);
            SetCartao(cartao);
        }

        public virtual void SetValor(decimal valor)
        {
            Valor = valor;
        }

        public virtual void SetDataVencimento(DateTime dataVencimento)
        {
            DataVencimento = dataVencimento;
        }

        public virtual void SetMesCorrespondente(DateTime dataMesCorrespondente)
        {
            MesCorrespondente = dataMesCorrespondente;
        }

        public virtual void SetCartao(Cartao cartao) 
        {
            Cartao = cartao;
        }
    }
}
