using System.Reflection;
using Entities.CQRS.Commands;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<LeagueAddCommand>());
builder.Services.AddDbContext<LeagueManagerContext>(options => options.UseSqlite($"Data Source={"leaguemanager.db"}"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ensure db is created and migrated
using (var scope = ((IApplicationBuilder) app).ApplicationServices.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<LeagueManagerContext>())
{
    context.Database.Migrate();
    context.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();