using BenchConApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenchConApp.Models;

public class NorthDbContext : DbContext
{
  public DbSet<Customer> Customers { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //base.OnConfiguring(optionsBuilder);
 
    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;")
      .EnableSensitiveDataLogging(false)
      .EnableDetailedErrors(true)
      .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
  }
}
