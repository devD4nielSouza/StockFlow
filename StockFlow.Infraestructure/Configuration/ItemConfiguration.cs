using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain.Entities;

namespace StockFlow.Infraestructure.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.id);

        builder.Property(i => i.nome).HasMaxLength(100).IsRequired();

        builder.Property(i => i.descricao).HasMaxLength(250);

        builder.Property(i => i.preco).IsRequired();

        builder.Property(i => i.estoque).IsRequired();

        builder.HasOne(p => p.Categoria)
        .WithMany(c => c.Items)
        .HasForeignKey(p => p.idCategoria)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
