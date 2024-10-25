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
        contexto.InitTransacao();
        contexto.GetDbSet<T>().Attach(entity);
        contexto.Entry(entity).State = EntityState.Modified;
        contexto.SendChanges();
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await contexto.GetDbSet<T>().Where(predicate).ToListAsync();
    }

    public async Task<int> Criar(T entity)
    {

        contexto.InitTransacao();
        var id = contexto.GetDbSet<T>().Add(entity).Entity;
        contexto.SendChanges();
        return 0;

    }

    public async Task Deletar(T entity)
    {
        contexto.InitTransacao();
        contexto.GetDbSet<T>().Remove(entity);
        contexto.SendChanges();

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
