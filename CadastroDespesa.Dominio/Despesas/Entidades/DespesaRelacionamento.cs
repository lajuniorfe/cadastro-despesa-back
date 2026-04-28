using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Despesas.Entidades
{
    public class DespesaRelacionamento : BaseEntidade
    {
        public virtual DateTime Data { get; protected set; }
        public virtual int NumeroParcela { get; protected set; }
        public virtual int TotalParcela { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual int? IdFatura { get; protected set; }
        public virtual Fatura? Fatura { get; protected set; }
        public virtual int IdDespesa { get; protected set; }
        public virtual Despesa? Despesa { get; protected set; }

        protected DespesaRelacionamento()
        {

        }

        public DespesaRelacionamento(DateTime data, int numeroParcela, int totalParcela, decimal valor, int idDespesa)
        {
            Data = data;
            NumeroParcela = numeroParcela;
            TotalParcela = totalParcela;
            Valor = valor;
            IdDespesa = idDespesa;
        }

        public void SetIdFatura(int idFatura)
        {
            IdFatura = idFatura;
        }

        public void SetData(DateTime data)
        {
            Data = data;

        }

        public void SetValor(decimal valor)
        {
            Valor = valor;
        }

        public void SetTotalParcela(int totalParcela)
        {
            TotalParcela = totalParcela;
        }

        public void SetNumeroParcela(int numeroParcela)
        {
            NumeroParcela = numeroParcela;
        }

        public static IList<DespesaRelacionamento> CriarFixa(int idDespesa, decimal valor, DateTime dataRecebida)
        {
            var despesasRelacionamento = new List<DespesaRelacionamento>();
            for (int mes = dataRecebida.Month; mes <= 12; mes++)
            {
                var data = new DateTime(dataRecebida.Year, mes, dataRecebida.Day);

                var despesaRelacionamento = new DespesaRelacionamento(data, 0, 0, valor, idDespesa);

                despesasRelacionamento.Add(despesaRelacionamento);
            }

            return despesasRelacionamento;
        }


        public static IList<DespesaRelacionamento> CriarParcelada(int idDespesa, decimal valor, DateTime dataInicial, int totalParcelas)
        {
            var listaDespesaRelacionamento = new List<DespesaRelacionamento>();

            for (int i = 0; i < totalParcelas; i++)
            {
                var valorParcela = valor / totalParcelas;
                var dataParcela = dataInicial.AddMonths(i);

                var despesaRelacionamento = new DespesaRelacionamento(dataParcela, i + 1, totalParcelas, valorParcela, idDespesa);

                listaDespesaRelacionamento.Add(despesaRelacionamento);
            }

            return listaDespesaRelacionamento;
        }

        public static IList<DespesaRelacionamento> AlterarParcelas(IList<DespesaRelacionamento> despesasRelacionamento, decimal valor, DateTime dataInicial, int totalParcelas)
        {
            for (int i = 0; i < totalParcelas; i++)
            {
                if(i+1 > despesasRelacionamento.Count)
                {
                    var valorParcela = valor / totalParcelas;
                    var dataParcela = dataInicial.AddMonths(i+1);

                    var despesaRelacionamento = new DespesaRelacionamento(dataParcela, i + 1, totalParcelas, valorParcela, despesasRelacionamento[0].Despesa.Id);

                    despesasRelacionamento.Add(despesaRelacionamento);
                }
                else
                {

                    var valorParcela = valor / totalParcelas;
                    var dataParcela = dataInicial.AddMonths(i+1);

                    despesasRelacionamento[i].SetData(dataParcela);
                    despesasRelacionamento[i].SetNumeroParcela(i + 1);
                    despesasRelacionamento[i].SetTotalParcela(totalParcelas);
                    despesasRelacionamento[i].SetValor(valorParcela);
                }

            }


            for (int i = despesasRelacionamento.Count - 1; i >= totalParcelas; i--)
            {
                despesasRelacionamento.RemoveAt(i);
            }

            return despesasRelacionamento;
        }


        public static DespesaRelacionamento CriarSemParcela(int idDespesa, decimal valor, DateTime dataRecebida)
        {
            var despesaRelacionamento = new DespesaRelacionamento(dataRecebida, 0, 0, valor, idDespesa);

            return despesaRelacionamento;
        }
    }
}
