using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {

        public DbSet<Computer>? Computers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=DotNetCourseDatabase;Uid=root;Pwd=devRoot123;", 
                optionsBuilder => optionsBuilder.EnableRetryOnFailure()); 
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