using EasyShoping.Domain.Entities;
using EasyShoping.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EasyShoping.Persistence.Contexts;

public class EasyShopingDbContext:DbContext
{
    public EasyShopingDbContext(DbContextOptions<EasyShopingDbContext> options):base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
    }
    DbSet<Product> products { get; set; }
    DbSet<Category> categories { get; set; }
    DbSet<Brand> brands { get; set; }
}
