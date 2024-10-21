using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using FluentNHibernate.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Despesas.Mapeamentos;

public class DespesaMap : IEntityTypeConfiguration<Despesa>
{
   public void Configure(EntityTypeBuilder<Despesa> builder){
        builder.ToTable("Despesas");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Descricao)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Valor)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(d => d.Data)
            .IsRequired();
    }       
}
