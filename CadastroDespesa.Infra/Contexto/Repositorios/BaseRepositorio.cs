using System;
using System.Linq.Expressions;
using CadastroDespesa.Dominio.Base.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace CadastroDespesa.Infra.Contexto.Repositorios;

public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
{
    protected readonly EntityContexto contexto;
    private readonly DbSet<T> _dbSet;

    public BaseRepositorio(EntityContexto contexto)
    {
        this.contexto = contexto;
        _dbSet =  this.contexto.Set<T>();
    }

    public async Task Alterar(T entity)
    {
        _dbSet.Update(entity);
        await contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task Criar(T entity)
    {
        await _dbSet.AddAsync(entity);
        await contexto.SaveChangesAsync();
    }

    public async Task Deletar(T entity)
    {
        _dbSet.Remove(entity);
        await contexto.SaveChangesAsync();

    }

    public async Task<T> ObterPorId(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }
}
