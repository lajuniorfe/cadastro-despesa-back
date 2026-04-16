using CadastroDespesa.Dominio.Despesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.Despesas.Mapeamentos
{
    public class DespesaRelacionamentoMap : IEntityTypeConfiguration<DespesaRelacionamento>
    {
        public void Configure(EntityTypeBuilder<DespesaRelacionamento> builder)
        {
            builder.ToTable("despesa_relacionamento");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");


            builder.Property(d => d.Valor).HasColumnName("valor")
                .IsRequired()
                .HasColumnType("numeric(18,2)");


            builder.Property(d => d.Data).HasColumnName("data")
                 .HasColumnType("timestamp without time zone")
                 .HasConversion( v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified), 
                                 v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified)  
                 ).IsRequired();

            builder.Property(d => d.NumeroParcela).HasColumnName("numero_parcela")
                .HasColumnType("integer");


            builder.Property(d => d.TotalParcela).HasColumnName("total_parcela")
                .HasColumnType("integer");

            builder.Property(d => d.IdFatura)
                .HasColumnName("id_fatura")
                .HasColumnType("integer");

            builder.Property(d => d.IdDespesa)
                .HasColumnName("id_despesa")
                .HasColumnType("integer");

            builder.HasOne(d => d.Fatura)
               .WithMany()
               .HasForeignKey(d => d.IdFatura);

            builder.HasOne(d => d.Despesa)
               .WithMany()
               .HasForeignKey(d => d.IdDespesa);

        }
    }
}
