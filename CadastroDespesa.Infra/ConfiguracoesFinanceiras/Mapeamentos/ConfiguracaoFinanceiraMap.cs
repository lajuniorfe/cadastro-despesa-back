using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.ConfiguracoesFinanceiras.Mapeamentos
{
    internal class ConfiguracaoFinanceiraMap : IEntityTypeConfiguration<ConfiguracaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoFinanceira> builder)
        {
            builder.ToTable("configuracao_financeira");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.PercentualEssencial).HasColumnName("percentual_essencial")
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(d => d.PercentualNaoEssencial).HasColumnName("percentual_nao_essencial")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(d => d.PercentualInvestimento).HasColumnName("percentual_investimento")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(d => d.ValorLimiteMensal).HasColumnName("valor_limite_mensal")
                .IsRequired()
                .HasColumnType("numeric(18,2)");

            builder.Property(d => d.Data).HasColumnName("data")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(d => d.IdUsuario)
                .HasColumnName("id_usuario")
                .HasColumnType("integer");

            builder.HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario);

        }
    }
}
