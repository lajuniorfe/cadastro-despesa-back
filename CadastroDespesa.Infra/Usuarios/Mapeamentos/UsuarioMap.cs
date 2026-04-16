using CadastroDespesa.Dominio.Usuarios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDespesa.Infra.Usuarios.Mapeamentos
{
    public class UsuarioMap: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.Nome)
               .HasColumnName("nome")
               .IsRequired();

            builder.Property(d => d.Login)
               .HasColumnName("login");


            builder.Property(d => d.Senha)
               .HasColumnName("senha");
               

        }
    }
}
