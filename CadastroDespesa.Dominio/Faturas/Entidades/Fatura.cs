using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Cartoes.Entidades;

namespace CadastroDespesa.Dominio.Faturas.Entidades
{
    public class Fatura : BaseEntidade
    {
        public virtual DateTime DataVencimento { get; protected set; }
        public virtual DateTime MesCorrespondente { get; protected set; }

        public virtual int IdCartao { get; protected set; }
        public virtual Cartao? Cartao { get; protected set; }

        public Fatura() { }
        public Fatura(DateTime dataVencimento, DateTime mesCorrespondente, int idCartao)
        {
            SetDataVencimento(dataVencimento);
            SetMesCorrespondente(mesCorrespondente);
            SetCartao(idCartao);
        }

        public void SetDataVencimento(DateTime dataVencimento)
        {
            DataVencimento = dataVencimento;
        }

        public void SetMesCorrespondente(DateTime dataMesCorrespondente)
        {
            MesCorrespondente = dataMesCorrespondente;
        }

        public void SetCartao(int idCartao)
        {
            IdCartao = idCartao;
        }

        public static DateTime CalcularDataFatura(DateTime dataDespesa, int fechamentoCartao, int vencimento)
        {
            DateTime dataFechamento = new DateTime(dataDespesa.Year, dataDespesa.Month, fechamentoCartao);
            if (dataDespesa <= dataFechamento)
            {
                if (fechamentoCartao > vencimento)
                {
                    return new DateTime(dataFechamento.Year, dataFechamento.Month, vencimento).AddMonths(1);
                }
                else
                {
                    return new DateTime(dataFechamento.Year, dataFechamento.Month, vencimento);
                }
            }
            else
            {
                if (fechamentoCartao > vencimento)
                {
                    return new DateTime(dataFechamento.Year, dataFechamento.Month, vencimento).AddMonths(2);
                }
                else
                {
                    return new DateTime(dataFechamento.Year, dataFechamento.Month, vencimento).AddMonths(1);
                }
            }
        }
    }
}
