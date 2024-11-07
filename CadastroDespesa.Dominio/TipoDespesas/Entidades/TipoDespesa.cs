using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.TipoDespesas.Entidades
{
    public class TipoDespesa : BaseEntidade
    {
        public virtual string? Nome { get; set; }
        public virtual string? Descricao { get; set; }

        public TipoDespesa() { }
        public TipoDespesa(string nome, string descricao)
        {
            SetNome(nome);
            SetDescricao(descricao);
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

    }
}
