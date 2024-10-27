using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;

namespace CadastroDespesa.Infra.Categorias.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(EntityContexto context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
