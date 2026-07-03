using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Investimentos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.Investimentos.Mapeamentos
{
    public class InvestimentoMap: IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.ToTable("investimento");

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


            builder.Property(d => d.Tipo).HasColumnName("tipo")
                .IsRequired()
                .HasColumnType("integer");



            builder.Property(d => d.Data)
               .HasColumnName("data")
               .HasColumnType("timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                 .HasConversion(v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified),
                                 v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified)
                 )
               .IsRequired();



            builder.Property(d => d.IdUsuario)
                 .HasColumnName("id_usuario")
                 .HasColumnType("integer")
                 .IsRequired();

            builder.HasOne(p => p.Usuario)
                       .WithMany()
                       .HasForeignKey(p => p.IdUsuario);


        }
    }
}
