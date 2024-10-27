using System;

namespace CadastroDespesa.Infra.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    void Rollback();
    void BeginTransaction();
}
