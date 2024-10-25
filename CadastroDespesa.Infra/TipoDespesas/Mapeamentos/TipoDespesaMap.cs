using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.TipoDespesas.Mapeamentos
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder)
        {
            builder.ToTable("tipo_despesa");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
