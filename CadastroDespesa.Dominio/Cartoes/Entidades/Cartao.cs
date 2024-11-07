using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.Cartoes.Entidades
{
    public class Cartao : BaseEntidade
    {
        public virtual string? Nome { get; protected set; }
        public virtual decimal Limite { get; protected set; }
        public virtual int Vencimento { get; protected set; }
        public virtual int Fechamento { get; protected set; }

        public Cartao()
        {

        }
        public Cartao(string nome, decimal limite, int vencimento, int fechamento)
        {
            SetNome(nome);
            SetLimite(limite);
            SetVencimento(vencimento);
            SetFechamento(fechamento);
        }

        public  void SetNome(string nome)
        {
            Nome = nome;
        }

        public  void SetLimite(decimal limite)
        {
            Limite = limite;
        }

        public  void SetVencimento(int vencimento)
        {
            Vencimento = vencimento;
        }

        public virtual void SetFechamento(int fechamento)
        {
            Fechamento = fechamento;
        }

        public static DateTime CalcularProximaDataVencimento( DateTime ultimoVencimento)
        {
            if (ultimoVencimento.Month == 12)
                return ultimoVencimento.AddMonths(1).AddYears(1);

            return ultimoVencimento.AddMonths(1);
        }

        public static DateTime CalcularProximaDataFechamento(DateTime ultimoFechamento)
        {
            if (ultimoFechamento.Month == 12)
                return ultimoFechamento.AddMonths(1).AddYears(1);

            return ultimoFechamento.AddMonths(1);
        }
    }
}
