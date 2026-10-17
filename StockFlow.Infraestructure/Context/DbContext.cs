using StockFlow.Domain.Entities;
using StockFlow.Infraestructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace StockFlow.Infraestructure.Context;

public class DbContext : IdentityDbContext<IdentityUser>
{
    public DbContext(DbContextOptions<DbContext> options)
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