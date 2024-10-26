using CadastroDespesa.Dominio.Faturas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Faturas.Mapeamentos
{
    public class FaturaMap: IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.ToTable("fatura");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.Valor)
                .HasColumnName("valor")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.MesCorrespondente)
               .HasColumnName("mes_correspondente")
               .HasColumnType("timestamp without time zone")
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(d => d.DataVencimento)
              .HasColumnName("data_vencimento")
              .HasColumnType("timestamp without time zone")
              .IsRequired()
              .HasMaxLength(100);

            builder.HasOne(p => p.Cartao)
                       .WithMany()
                       .HasForeignKey("id_cartao");
        }
    }
}
