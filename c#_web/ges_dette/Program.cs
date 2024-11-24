using Cours.Data;
using Cours.Fixtures;
using Cours.Services;
using Cours.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Utilisation de MySQL au lieu de SQL Server
string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 3, 0))));
// Add services to the container.
// Configure the services for the application.
/* 
    AddTransient => Créer à chaque fois qu'on a une injection de dependance
    AddScoped => Créer une instance unique pour la durée de la requête
    AddSingleton => Créer une instance unique pour toute la durée de l'application
 */
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDetteService, DetteService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<ClientFixtures>();

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Client}/{action=Index}");
using (var scope = app.Services.CreateScope())

{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    seeder.Load();
}    

app.Run();
