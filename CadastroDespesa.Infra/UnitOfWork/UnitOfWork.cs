using System;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace CadastroDespesa.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EntityContexto contexto;
    private IDbContextTransaction _transaction;

    public UnitOfWork(EntityContexto contexto, IDbContextTransaction _transaction)
    {
        this.contexto = contexto;
        this._transaction = _transaction;
    }

    public async Task CommitAsync()
    {
        await contexto.SaveChangesAsync();
        _transaction.Commit();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        contexto.Dispose();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void BeginTransaction()
    {
        _transaction = contexto.Database.BeginTransaction();
    }
}
