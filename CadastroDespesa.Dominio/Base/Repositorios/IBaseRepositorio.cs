using CadastroDespesa.Dominio.Base.Entidades;
using System;
using System.Linq.Expressions;

namespace CadastroDespesa.Dominio.Base.Repositorios;

public interface IBaseRepositorio<T> where T : BaseEntidade
{
    Task<IEnumerable<T>> ObterTodos();
    Task<T> ObterPorId(int id);
    Task<IEnumerable<T>> Listar(Expression<Func<T, bool>> predicate);
    Task<T>Buscar(Expression<Func<T, bool>> predicate);
    Task<int> Criar(T entity);
    Task Alterar(T entity);
    Task Deletar(T entity);
}
