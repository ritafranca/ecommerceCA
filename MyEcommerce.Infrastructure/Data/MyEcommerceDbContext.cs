using Microsoft.EntityFrameworkCore;
using MyEcommerce.Domain.Entities;

namespace MyEcommerce.Infrastructure.Data
{
    public class MyEcommerceDbContext : DbContext
    {
        public MyEcommerceDbContext(DbContextOptions<MyEcommerceDbContext> options)
            : base(options) { }

        // ✅ Ensure these DbSets exist
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
        }
    }
}

