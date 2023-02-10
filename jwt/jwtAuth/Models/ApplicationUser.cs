using Microsoft.AspNetCore.Identity;

namespace jwtAuth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;
    }
}
