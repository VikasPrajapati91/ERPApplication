using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int? ParentMenuId { get; set; }  // Nullable to allow top-level menus
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        // Self-referencing relationship for parent-child hierarchy
        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> ChildMenus { get; set; } = new List<Menu>();

        // Navigation property for UserMenu
        public virtual ICollection<UserMenu> UserMenus { get; set; } = new List<UserMenu>();
    }
}
