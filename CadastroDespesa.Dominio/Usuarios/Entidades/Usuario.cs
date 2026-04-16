using CadastroDespesa.Dominio.Base.Entidades;

namespace CadastroDespesa.Dominio.Usuarios.Entidades
{
    public class Usuario: BaseEntidade
    {
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
    }
}
