using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Infra.Despesas.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace CadastroDespesa.Infra.Contexto;

public class EntityContexto : DbContext
{
    public EntityContexto(DbContextOptions<EntityContexto> options) : base(options){
    }

    public DbSet<Despesa> Despesas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfiguration(new DespesaMap());
    }
}
