using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Base.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDespesa.Infra.Contexto.Repositorios;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseEntidade
{
    protected EntityContexto contexto;
    protected DbSet<T> _dbSet;

    public BaseRepositorio(EntityContexto contexto)
    {
        this.contexto = contexto;
        _dbSet = contexto.Set<T>();
    }
    public async Task Alterar(T entity)
    {
        contexto.Update(entity);
        await contexto.SaveChangesAsync();
    }

    public async Task AlterarLista(IList<T> entity)
    {
        contexto.UpdateRange(entity);
        await contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).FirstOrDefaultAsync();
    }
    public async Task<T> Criar(T entity)
    {
        await contexto.AddAsync(entity);
        await contexto.SaveChangesAsync();
        return entity;
    }

    public async Task Deletar(T entity)
    {
        contexto.Remove(entity);
        await contexto.SaveChangesAsync();
    }

    public async Task<T> ObterPorId(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entidade com Id {id} não encontrada.");
        }

        return entity;
    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> CriarLista(IEnumerable<T> entities)
    {
        await contexto.AddRangeAsync(entities);
        await contexto.SaveChangesAsync();
        return entities;
    }

    public async Task DeletarLista(IList<T> entity)
    {
        contexto.RemoveRange(entity);
        await contexto.SaveChangesAsync();
    }
}
