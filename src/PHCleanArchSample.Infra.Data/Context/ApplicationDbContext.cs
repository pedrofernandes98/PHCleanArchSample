using Microsoft.EntityFrameworkCore;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public ApplicationDbContext()
        {
            
        }

        public DbSet<Category> Categories;

        public DbSet<Product> Products;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
