using CadastroDespesa.Dominio.Recorrencias.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Recorrencias.Mapeamentos
{
    public class TipoDespesaMap : IEntityTypeConfiguration<Recorrencia>
    {
        public void Configure(EntityTypeBuilder<Recorrencia> builder)
        {
            builder.ToTable("recorrencia");

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
