using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Base.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDespesa.Infra.Contexto.Repositorios;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseEntidade
{
    protected readonly EntityContexto contexto;
    private readonly IUnitOfWork unitOfWork;

    public BaseRepositorio(EntityContexto contexto, IUnitOfWork unitOfWork)
    {
        this.contexto = contexto;
        this.unitOfWork = unitOfWork;
    }

    public void Alterar(T entity)
    {
        contexto.GetDbSet<T>().Attach(entity);
        contexto.Entry(entity).State = EntityState.Modified;
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await contexto.GetDbSet<T>().Where(predicate).ToListAsync();
    }

    public int Criar(T entity)
    {
        var id = contexto.GetDbSet<T>().Add(entity).Entity;
        return entity.Id;
    }

    public void Deletar(T entity)
    {
        contexto.GetDbSet<T>().Remove(entity);
    }

    public async Task<T> ObterPorId(int id)
    {
        return await contexto.GetDbSet<T>().FindAsync(id);
    }

    public IEnumerable<T> ObterTodos()
    {
        return  contexto.GetDbSet<T>().ToList();
    }

}
