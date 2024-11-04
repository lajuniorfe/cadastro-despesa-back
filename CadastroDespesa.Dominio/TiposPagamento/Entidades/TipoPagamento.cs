using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.TiposPagamento.Entidades
{
    public class TipoPagamento : BaseEntidade
    {
        public virtual string? Nome { get; protected set; }

        public TipoPagamento()
        {

        }
        public TipoPagamento(string? nome)
        {
            SetNome(nome);
        }
        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}
