using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Cartoes.Entidades
{
    public class Cartao
    {
        public virtual int Id { get; protected set; }
        public virtual string? Nome { get; protected set; }
        public virtual decimal Limite { get; protected set; }
        public virtual int Vencimento { get; protected set; }
        public virtual int Fechamento { get; protected set; }

        public Cartao(string nome, decimal limite, int vencimento, int fechamento)
        {
            SetNome(nome);
            SetLimite(limite);
            SetVencimento(vencimento);
            SetFechamento(fechamento);
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }

        public virtual void SetLimite(decimal limite)
        {
            Limite = limite;
        }

        public virtual void SetVencimento(int vencimento)
        {
            Vencimento = vencimento;
        }

        public virtual void SetFechamento(int fechamento)
        {
            Fechamento = fechamento;
        }

        public DateTime CalcularProximaDataVencimento( DateTime ultimoVencimento)
        {
            if (ultimoVencimento.Month == 12)
                return ultimoVencimento.AddMonths(1).AddYears(1);

            return ultimoVencimento.AddMonths(1);
        }

        public DateTime CalcularProximaDataFechamento(DateTime ultimoFechamento)
        {
            if (ultimoFechamento.Month == 12)
                return ultimoFechamento.AddMonths(1).AddYears(1);

            return ultimoFechamento.AddMonths(1);
        }
    }
}
