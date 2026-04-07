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
            .HasColumnType("numeric(18,2)");


        builder.Property(d => d.ValorParcela).HasColumnName("valor_parcela")
            .HasColumnType("numeric(18,2)");

        builder.Property(d => d.Data).HasColumnName("data_despesa")
             .HasColumnType("timestamp without time zone")
             .IsRequired();

        builder.Property(d => d.NumeroParcela).HasColumnName("numero_parcela")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(d => d.TotalParcela).HasColumnName("total_parcela")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(d => d.IdCategoria)
             .HasColumnName("id_categoria")
             .HasColumnType("integer")
             .IsRequired();

        builder.Property(d => d.IdRecorrencia)
            .HasColumnName("id_recorrencia")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(d => d.IdFatura)
         .HasColumnName("id_fatura")
         .HasColumnType("integer");
       

        builder.HasOne(d => d.Categoria)
            .WithMany()
            .HasForeignKey(d => d.IdCategoria);

        builder.HasOne(d => d.Recorrencia)
            .WithMany()
            .HasForeignKey(d => d.IdRecorrencia);

        builder.HasOne(d => d.Fatura)
           .WithMany()
           .HasForeignKey(d => d.IdFatura);

    }
}
