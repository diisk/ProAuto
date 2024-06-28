using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProAuto.Data;
using ProAuto.Interfaces.Repositories;
using ProAuto.Interfaces.Services;
using ProAuto.Repositories;
using ProAuto.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAssociadoRepository, AssociadoRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IAssociadoService, AssociadoService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Associado}/{action=Pesquisar}/{id?}");

app.Run();
