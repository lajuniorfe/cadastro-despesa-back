using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Entidades
{
    public class Recorrencia : BaseEntidade
    {
        public virtual string? Nome { get; set; }
        public virtual string? Descricao { get; set; }

        public Recorrencia() { }
        public Recorrencia(string nome, string descricao)
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
