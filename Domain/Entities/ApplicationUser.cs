using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser     {
        // Custom properties for your user domain model
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property
        public virtual ICollection<UserMenu> UserMenus { get; set; } = new List<UserMenu>();
    }
}
