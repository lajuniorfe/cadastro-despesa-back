using CadastroDespesa.Dominio.Categorias.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Categorias.Mapeamentos
{
    public class CategoriaMap: IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.Nome).HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
