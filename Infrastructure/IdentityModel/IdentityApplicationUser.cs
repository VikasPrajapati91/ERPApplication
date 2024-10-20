using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.IdentityModel
{
    public class IdentityApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property (optional)
        public virtual ICollection<UserMenu> UserMenus { get; set; }
    }
}
