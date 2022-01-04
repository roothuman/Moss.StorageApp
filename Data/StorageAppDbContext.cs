using Microsoft.EntityFrameworkCore;
using Moss.StorageApp.Entities;

namespace Moss.StorageApp.Data
{
   public class StorageAppDbContext : DbContext
   {
       public DbSet<Employee> Employees => Set<Employee>();
       public DbSet<Organization> Organizations => Set<Organization>();

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseInMemoryDatabase("StorageAppDb");
       }

    }
}
