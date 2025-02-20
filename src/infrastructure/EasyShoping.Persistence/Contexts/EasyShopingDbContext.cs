using EasyShoping.Domain.Entities;
using EasyShoping.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShoping.Persistence.Contexts;

public class EasyShopingDbContext:IdentityDbContext<AppUser,Role,Guid>
{
    public EasyShopingDbContext(DbContextOptions<EasyShopingDbContext> options):base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(r => new { r.UserId, r.RoleId });
        modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
    }
    DbSet<UserProduct> userProducts { get; set; }
    DbSet<Product> products { get; set; }
    DbSet<Category> categories { get; set; }
    DbSet<Brand> brands { get; set; }
}
