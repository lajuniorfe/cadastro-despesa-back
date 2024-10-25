using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.Categorias.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(EntityContexto context) : base(context) { }
    }
}
