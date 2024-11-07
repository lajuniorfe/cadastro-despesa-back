using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Base.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDespesa.Infra.Contexto.Repositorios;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseEntidade
{
    protected readonly EntityContexto contexto;
    public BaseRepositorio(EntityContexto contexto)
    {
        this.contexto = contexto;
    }
    public async Task Alterar(T entity)
    {
        contexto.GetDbSet<T>().Attach(entity);
        contexto.Entry(entity).State = EntityState.Modified;
        await contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> predicate)
    {
        return await contexto.GetDbSet<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await contexto.GetDbSet<T>().Where(predicate).FirstAsync();
    }
    public async Task<int> Criar(T entity)
    {
        await contexto.GetDbSet<T>().AddAsync(entity);
        await contexto.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Deletar(T entity)
    {
        contexto.GetDbSet<T>().Remove(entity);
    }

    public async Task<T> ObterPorId(int id)
    {
        var entity = await contexto.GetDbSet<T>().FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entidade com Id {id} não encontrada.");
        }

        return entity;

    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        return await contexto.GetDbSet<T>().ToListAsync();
    }

}
