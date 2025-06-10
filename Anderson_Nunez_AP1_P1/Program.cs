using Anderson_Nunez_AP1_P1;
using Anderson_Nunez_AP1_P1.Components;
using Anderson_Nunez_AP1_P1.DAL;
using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();

// Inyeccion del servicio Toast 
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<AportesService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Contexto
var ConString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
