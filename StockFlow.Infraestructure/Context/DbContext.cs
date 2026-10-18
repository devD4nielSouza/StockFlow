using StockFlow.Domain.Entities;
using StockFlow.Infraestructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

namespace StockFlow.Infraestructure.Context;

public class StockDbContext : IdentityDbContext<IdentityUser>
{
    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

        public DbSet<Item> Item { get; set; }
        public DbSet<Categoria> Categoria {get;set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }
}