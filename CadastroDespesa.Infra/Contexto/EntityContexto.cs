using CadastroDespesa.Dominio.Base.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace CadastroDespesa.Infra.Contexto;

public class EntityContexto : DbContext
{
    public IDbContextTransaction Transaction { get; private set; }
  
    public EntityContexto(DbContextOptions<EntityContexto> options) : base(options)
    {
        if (Database.GetPendingMigrations().Count() > 0)
            Database.Migrate();
    }
    public DbSet<T> GetDbSet<T>() where T : BaseEntidade
    {
        return Set<T>();
    }


    public IDbContextTransaction InitTransacao()
    {
        if (Transaction == null) Transaction = this.Database.BeginTransaction();
        return Transaction;
    }

    public void RollBack()
    {
        if (Transaction != null)
        {
            Transaction.Rollback();
        }
    }

    private void Salvar()
    {
        try
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }
        catch (Exception ex)
        {
            RollBack();
            throw new Exception(ex.Message);
        }
    }

    private void Commit()
    {
        if (Transaction != null)
        {
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }
    }

    public void SendChanges()
    {
        Salvar();
        Commit();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
