using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasPrecision(10,2)
                .IsRequired();

            builder.HasOne(c => c.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
