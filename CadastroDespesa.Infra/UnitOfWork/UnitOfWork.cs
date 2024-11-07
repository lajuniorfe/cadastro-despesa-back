using System;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.Infra.Contexto;
using Microsoft.EntityFrameworkCore.Storage;

namespace CadastroDespesa.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly EntityContexto contexto;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(EntityContexto contexto)
    {
        this.contexto = contexto;
    }

    public async Task CommitAsync()
    {
        try
        {
            if (_transaction == null)
            {
                _transaction = await contexto.Database.BeginTransactionAsync();
            }

            await contexto.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
        finally
        {
            await DisposeAsync();
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Erro ao dar roolbaclk");
        }

        await _transaction.RollbackAsync();
        await DisposeAsync();
    }

    public async Task BeginTransaction()
    {

        if (_transaction != null)
        {
            throw new InvalidOperationException("Já existe uma transação aberta.");
        }

        _transaction = await contexto.Database.BeginTransactionAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
        }
        await contexto.DisposeAsync();
    }
}
