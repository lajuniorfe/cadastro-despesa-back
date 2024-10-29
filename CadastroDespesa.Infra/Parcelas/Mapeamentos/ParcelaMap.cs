using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.Parcelas.Mapeamentos
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("parcela");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("interger");

            builder.Property(d => d.Valor)
                .HasColumnName("valor")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.NumeroParcela)
               .HasColumnName("numero_parcela")
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(d => d.Data)
              .HasColumnName("data")
              .HasColumnType("timestamp without time zone")
              .IsRequired()
              .HasMaxLength(100);

            builder.HasOne(p => p.Despesa)
                       .WithMany()
                       .HasForeignKey("id_jurema");


            builder.HasOne(p => p.Fatura)
                      .WithMany()
                      .HasForeignKey("id_fatura");
        }
    }
}
