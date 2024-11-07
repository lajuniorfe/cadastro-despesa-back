using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.Categorias.Entidades
{
    public class Categoria : BaseEntidade
    {
        public virtual string? Nome { get; protected set; }

        public Categoria()
        {

        }
        public Categoria(string nome)
        {
            SetNome(nome);
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}
