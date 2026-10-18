using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockFlow.Domain.Entities;
using StockFlow.Infraestructure.Context;

namespace StockFlow.Infraestructure.Identity;

public class SeedData
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {

        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StockDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await context.Database.MigrateAsync();
        Console.WriteLine("SEEDDATA INICIADO !!");
        // =====================================================================
        // 1. SEED DE CATEGORIAS
        // =====================================================================
        if (!context.Categoria.Any())
        {
            var categories = new List<Categoria>
                {
                    new Categoria{ nome = "Smartphones"},
                    new Categoria{ nome = "TVs"},
                    new Categoria{ nome = "Móveis"},
                    new Categoria{ nome = "Roupas"},
                };

            await context.Categoria.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }



        await context.SaveChangesAsync();

        // =====================================================================
        // 2. SEED DE PRODUTOS
        // =====================================================================
        if (!context.Item.Any())
        {

            var celular = await context.Categoria.FirstAsync(c => c.nome == "Smartphones");
            var tv = await context.Categoria.FirstAsync(c => c.nome == "TVs");
            var movel = await context.Categoria.FirstAsync(c => c.nome == "Móveis");
            var roupa = await context.Categoria.FirstAsync(c => c.nome == "Roupas");

            var items = new List<Item>
                {
                    new Item
                    {
                        nome = "Samsung Galaxy S21",
                        descricao = "Samsung Galaxy S21 top de linha",
                        preco = 10,
                        idCategoria = celular.id,
                        criadoEm = DateTime.Now

                    },
                    new Item
                    {
                        nome = "Tv 45 polegads",
                        descricao = "Tv 45 polegadas philco",
                        preco = 10,
                        idCategoria = tv.id,
                        criadoEm = DateTime.Now

                    },
                    new Item
                    {
                       nome = "Calça Baggy camuflada",
                        descricao = "Calça Baggy camuflada verde",
                        preco = 10,
                        idCategoria = roupa.id,
                        criadoEm = DateTime.Now

                    },
                    new Item
                    {
                        nome = "Sofá 2 lugares",
                        descricao = "Sofa 2 lugares muito confortavel",
                        preco = 10,
                        idCategoria = movel.id,
                        criadoEm = DateTime.Now
                    }
                };

            await context.Item.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }

        // =====================================================================
        // 3. SEED DE ROLES (Papéis de Usuário)
        // =====================================================================
        // 📌 CONCEITO: Roles no Identity
        // Roles são papéis que definem o nível de acesso do usuário.
        // Exemplo: "Admin" pode gerenciar produtos, "User" só pode visualizar.
        // =====================================================================
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("Usuario"))
        {
            await roleManager.CreateAsync(new IdentityRole("Usuario"));
        }

        // =====================================================================
        // 4. SEED DO USUÁRIO ADMINISTRADOR
        // =====================================================================
        // 📌 CONCEITO: UserManager
        // O UserManager é o serviço do Identity para gerenciar usuários.
        // Ele permite criar, buscar, atualizar e deletar usuários.
        // =====================================================================
        var adminEmail = "admin@email.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}