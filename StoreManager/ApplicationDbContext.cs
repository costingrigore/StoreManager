using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreManager.Entities;

namespace StoreManager
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        IConfiguration configuration = new ConfigurationBuilder()
       .AddJsonFile("appSettings.json", true, true)
       .Build();

        
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext()
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
