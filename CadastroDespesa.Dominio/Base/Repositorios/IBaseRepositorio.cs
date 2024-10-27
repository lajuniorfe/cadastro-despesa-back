using CadastroDespesa.Dominio.Base.Entidades;
using System;
using System.Linq.Expressions;

namespace CadastroDespesa.Dominio.Base.Repositorios;

public interface IBaseRepositorio<T> where T : BaseEntidade
{
    IEnumerable<T> ObterTodos();
    Task<T> ObterPorId(int id);
    Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
    int Criar(T entity);
    void Alterar(T entity);
    void Deletar(T entity);
}
