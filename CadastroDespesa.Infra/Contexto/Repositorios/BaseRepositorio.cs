using CadastroDespesa.Dominio.Base.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDespesa.Infra.Contexto.Repositorios;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
{
    protected readonly EntityContexto contexto;

    public BaseRepositorio(EntityContexto contexto) : base()
    {
        this.contexto = contexto;
    }

    public async Task Alterar(T entity)
    {
        contexto.InitTransacao();
        contexto.Set<T>().Attach(entity);
        contexto.Entry(entity).State = EntityState.Modified;
        contexto.SendChanges();
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await contexto.Set<T>().ToListAsync();
    }

    public async Task<int> Criar(T entity)
    {

        contexto.InitTransacao();
        var id = contexto.Set<T>().Add(entity).Entity;
        contexto.SendChanges();
        return 0;

    }

    public async Task Deletar(T entity)
    {
        contexto.InitTransacao();
        contexto.Set<T>().Remove(entity);
        contexto.SendChanges();

    }

    public async Task<T> ObterPorId(int id)
    {
        return await contexto.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        return await contexto.Set<T>().ToListAsync();
    }

}
