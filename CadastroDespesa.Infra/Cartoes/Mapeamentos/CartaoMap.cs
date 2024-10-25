using CadastroDespesa.Dominio.Cartoes.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Cartoes.Mapeamentos
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("cartao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnName("nome");

            builder.Property(c => c.Limite)
               .IsRequired()
               .HasColumnName("limite")
               .HasColumnType("integer");

            builder.Property(c => c.Vencimento)
               .IsRequired()
               .HasColumnName("vencimento")
               .HasColumnType("integer");

            builder.Property(c => c.Fechamento)
               .IsRequired()
               .HasColumnName("fechamento")
               .HasColumnType("integer");
        }
    }
}
