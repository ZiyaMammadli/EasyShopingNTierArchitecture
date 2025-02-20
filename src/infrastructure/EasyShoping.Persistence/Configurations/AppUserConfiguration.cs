using EasyShoping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShoping.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u=>u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.RefreshToken).IsRequired().HasMaxLength(450);

        builder
            .HasMany(u=>u.userProducts)
            .WithOne(up=>up.User)
            .HasForeignKey(up=>up.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
