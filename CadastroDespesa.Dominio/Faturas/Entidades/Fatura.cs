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

        public void SetValor(decimal valor)
        {
            Valor = valor;
        }

        public void SetDataVencimento(DateTime dataVencimento)
        {
            DataVencimento = dataVencimento;
        }

        public void SetMesCorrespondente(DateTime dataMesCorrespondente)
        {
            MesCorrespondente = dataMesCorrespondente;
        }

        public void SetCartao(Cartao cartao)
        {
            Cartao = cartao;
        }

        public static DateTime CalcularDataFatura(DateTime dataDespesa, int fechamentoCartao)
        {

            var dataFaturaAtual = new DateTime(dataDespesa.Year, dataDespesa.Month, fechamentoCartao);

            if(dataDespesa <= dataFaturaAtual)
            {
                return dataFaturaAtual;
            }
            else
            {
               return dataFaturaAtual.AddMonths(1);
            }
        }
    }
}
