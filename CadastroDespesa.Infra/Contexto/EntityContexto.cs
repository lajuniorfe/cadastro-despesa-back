using CadastroDespesa.Dominio.Base.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using System.Net.Sockets;
using System.Reflection;

namespace CadastroDespesa.Infra.Contexto;

public class EntityContexto : DbContext
{
    public EntityContexto(DbContextOptions<EntityContexto> options) : base(options)
    {
        if (Database.GetPendingMigrations().Count() > 0)
            Database.Migrate();
    }

    public DbSet<T> GetDbSet<T>() where T : BaseEntidade
    {
        return Set<T>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    
}
