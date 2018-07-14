using Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infra.Data
{
  public class ContextDB : DbContext
  {
    public DbSet<Post> Post { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var config = new ConfigurationBuilder()
       .Build();

      optionsBuilder.UseSqlServer("Server=WAGNER-PC;Database=Teste;Trusted_Connection=True;MultipleActiveResultSets=True");
    }
  }
}
