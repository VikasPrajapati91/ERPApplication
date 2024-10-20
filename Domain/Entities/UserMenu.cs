using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserMenu
    {
        public string UserId { get; set; }  // Corresponds to AspNetUsers.Id (nvarchar)
        public int MenuId { get; set; }
        public bool AccessGranted { get; set; } = true;

        // Navigation properties
        public virtual Menu Menu { get; set; }
        public virtual ApplicationUser User { get; set; } // Assuming IdentityUser from ASP.NET Core Identity
    }

}
