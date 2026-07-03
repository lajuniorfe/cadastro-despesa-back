using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Investimentos.Enums;
using CadastroDespesa.Dominio.Usuarios.Entidades;

namespace CadastroDespesa.Dominio.Investimentos.Entidades
{
    public class Investimento : BaseEntidade
    {
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public TipoInvestimentoEnum Tipo { get; set; }
        public DateTime Data { get; set; }

        public int IdUsuario { get;  set; }
        public Usuario? Usuario { get;  set; }
    }
}
