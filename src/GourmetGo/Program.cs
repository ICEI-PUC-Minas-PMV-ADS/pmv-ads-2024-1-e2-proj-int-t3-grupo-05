using GourmetGo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "cliente",
    pattern: "cliente/{id:int}",
    defaults: new { controller = "Cliente", action = "Index" });

app.MapControllerRoute(
    name: "cardapio",
    pattern: "cliente/{id:int}/cardapio",
    defaults: new { controller = "Cliente", action = "Cardapio" });

app.MapControllerRoute(
    name: "pedidos",
    pattern: "cliente/{id:int}/pedidos",
    defaults: new { controller = "Cliente", action = "Pedidos" });

app.MapControllerRoute(
    name: "configuracoes",
    pattern: "cliente/{id:int}/configuracoes",
    defaults: new { controller = "Cliente", action = "Configuracoes" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
