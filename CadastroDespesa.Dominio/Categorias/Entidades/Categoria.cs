using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.Categorias.Entidades
{
    public class Categoria : BaseEntidade
    {
        public virtual string? Nome { get; protected set; }
        public virtual int Tipo { get; protected set; }

        protected Categoria() {}

        public Categoria(string nome)
        {
            SetNome(nome);
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetTipo(int tipo)
        {
            Tipo = tipo;
        }
    }
}
