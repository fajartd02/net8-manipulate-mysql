using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        private IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Computer>? Computers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? _connectionString = _config.GetConnectionString("DefaultConnection");
                if(_connectionString != null) {
                    optionsBuilder.UseMySQL(_connectionString, 
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure()); 
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Computer>()
                .ToTable("Computer")
                .HasKey(c => c.ComputerId);
        }

    }
}