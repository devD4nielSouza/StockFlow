using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain.Entities;

namespace StockFlow.Infraestructure.Configuration;

public class LogItemsConfiguration: IEntityTypeConfiguration<LogItems>
{
    public void Configure(EntityTypeBuilder<LogItems> builder)
    {
        builder.HasKey(l => l.id);

        builder.Property(l => l.itemId).IsRequired();

        builder.Property(l => l.userId).IsRequired();

        builder.HasOne(l => l.item)
            .WithMany(i => i.Logs)
            .HasForeignKey(l => l.itemId);
    }
}
