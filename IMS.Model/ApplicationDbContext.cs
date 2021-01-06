using IMS.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("IMS_Connection"));                
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(prop => prop.Title).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(prop => prop.Code).IsUnique();
            modelBuilder.Entity<Product>().Property(prop => prop.Title).IsRequired();
            modelBuilder.Entity<Product>().Property(prop => prop.Title).IsRequired();
            modelBuilder.Entity<Product>().Property(prop => prop.Code).IsRequired();
            modelBuilder.Entity<Product>().Property(prop => prop.CreationDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
