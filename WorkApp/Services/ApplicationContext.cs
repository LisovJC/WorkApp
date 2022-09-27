using Microsoft.EntityFrameworkCore;
using WorkApp.Model;

namespace WorkApp.Services
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=workapp.db");
        }
    }
}
