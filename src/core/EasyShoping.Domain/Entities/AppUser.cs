using Microsoft.AspNetCore.Identity;

namespace EasyShoping.Domain.Entities;

public class AppUser:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsDeleted { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireTime { get; set; }
    public List<UserProduct>? userProducts { get; set; }

}
