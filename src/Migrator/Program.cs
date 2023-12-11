// See https://aka.ms/new-console-template for more information

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
LeagueManagerContext context = new LeagueManagerContext();
try
{
    await context.Database.MigrateAsync();
    context.Database.EnsureCreated();

}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}