using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Interfaces;
using StockFlow.Application.Services;
using StockFlow.Domain.Interfaces;
using StockFlow.Infraestructure.Context;
using StockFlow.Infraestructure.Identity;
using StockFlow.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{

    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})

.AddEntityFrameworkStores<StockDbContext>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; 
    options.LogoutPath = "/Account/Logout"; 
    options.AccessDeniedPath = "/Account/AccessDenied"; 
});


builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();


builder.Services.AddControllersWithViews();


var app = builder.Build();


if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); // Habilita a autenticação (login)
app.UseAuthorization(); // Habilita a autorização (permissões)

app.MapControllerRoute(
   
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


await SeedData.SeedAsync(app.Services);

app.Run();