using Microsoft.AspNetCore.Identity;

namespace Lumina.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        // Navigation property for UserProfile
        public Profile Profile { get; set; }
    }
}
