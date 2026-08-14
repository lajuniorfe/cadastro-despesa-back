using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Investimentos.Enums;
using CadastroDespesa.Dominio.Usuarios.Entidades;

namespace CadastroDespesa.Dominio.Investimentos.Entidades
{
    public class Investimento : BaseEntidade
    {
        public decimal Valor { get; protected set; }
        public string Descricao { get; protected set; }
        public TipoInvestimentoEnum Tipo { get; protected set; }
        public DateTime Data { get; protected set; }

        public int IdUsuario { get; protected set; }
        public Usuario? Usuario { get; protected set; }

        protected Investimento() { }

        public Investimento(decimal valor, string descricao, TipoInvestimentoEnum tipo, DateTime data, int idUsuario)
        {
            Valor = valor;
            Descricao = descricao;
            Tipo = tipo;
            Data = data;
            IdUsuario = idUsuario;
        }
    }
}
