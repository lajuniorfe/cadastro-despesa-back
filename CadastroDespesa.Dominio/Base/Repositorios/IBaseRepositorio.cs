using System;
using System.Linq.Expressions;

namespace CadastroDespesa.Dominio.Base.Repositorios;

public interface IBaseRepositorio<T> where T : class
{
    Task<IEnumerable<T>> ObterTodos();
    Task<T> ObterPorId(int id);
    Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
    Task Criar(T entity);
    Task Alterar(T entity);
    Task Deletar(T entity);
}