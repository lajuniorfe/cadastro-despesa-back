using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.TransacoesDespesas.Mapeamentos
{
    public class TransacaoDespesaMap : IEntityTypeConfiguration<TransacaoDespesa>
    {
        public void Configure(EntityTypeBuilder<TransacaoDespesa> builder)
        {
            builder.ToTable("transacao_despesa");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Id)
                  .IsRequired()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            builder.Property(d => d.Valor).HasColumnName("valor")
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(d => d.StatusPagamento)
                .HasColumnName("status_pagamento")
                .IsRequired()
                .HasColumnType("boolean");


            builder.Property(d => d.Data)
                .HasColumnName("data")
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.HasOne(p => p.TipoPagamento)
                         .WithMany()
                         .HasForeignKey("id_tipopagamento");

            builder.HasOne(p => p.Despesa)
                         .WithMany()
                         .HasForeignKey("id_despesa");
        }
    }
}
