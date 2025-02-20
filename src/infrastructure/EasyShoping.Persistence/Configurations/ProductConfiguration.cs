using EasyShoping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShoping.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p=>p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p=>p.SalePrice).IsRequired();
        builder.Property(p=>p.CostPrice).IsRequired();
        builder.HasKey(p => p.Id);
        builder
            .HasOne(p=>p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
        builder
            .HasOne(p=>p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId);
        builder
            .HasMany(p => p.userProducts)
            .WithOne(up => up.Product)
            .HasForeignKey(up => up.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
