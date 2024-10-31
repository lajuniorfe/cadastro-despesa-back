using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Despesas.Mapeamentos;

public class DespesaMap : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.ToTable("despesa");

        builder.HasKey(d => d.Id);

        builder.Property(c => c.Id)
              .IsRequired()
              .HasColumnName("id")
              .HasColumnType("integer");

        builder.Property(d => d.Descricao).HasColumnName("descricao")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Valor).HasColumnName("valor")
            .IsRequired()
            .HasColumnType("numeric");

        builder.Property(d => d.StatusPagamento)
          .HasColumnName("status_pagamento")
          .IsRequired()
          .HasColumnType("boolean");

        builder.Property(d => d.Data).HasColumnName("data_despesa")
             .HasColumnType("timestamp without time zone")
             .IsRequired();

        builder.HasOne(p => p.Categoria)
                     .WithMany()
                     .HasForeignKey("id_categoria");

        builder.HasOne(p => p.TipoDespesa)
                     .WithMany()
                     .HasForeignKey("id_tipodespesa");

        builder.HasOne(p => p.TipoPagamento)
                     .WithMany()
                     .HasForeignKey("id_tipopagamento");
    }
}
