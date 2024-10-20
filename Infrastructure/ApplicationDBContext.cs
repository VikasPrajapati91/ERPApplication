using Domain.Entities;
using Infrastructure.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDBContext : IdentityDbContext<IdentityApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuring relationships
            //Menu
            builder.Entity<Menu>()
                .HasMany(m => m.ChildMenus)
                .WithOne(m => m.ParentMenu)
                .HasForeignKey(m => m.ParentMenuId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascading delete for parent-child relationship

            //TemplateMenu
            builder.Entity<TemplateMenu>()
                .HasKey(tm => new { tm.TemplateId, tm.MenuId });

            //UserMenu
            builder.Entity<UserMenu>()
                .HasKey(um => new { um.UserId, um.MenuId });         
            
             builder.Entity<UserMenu>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMenus)
                .HasForeignKey(um => um.UserId);

            builder.Entity<UserMenu>()
                .HasOne(um => um.Menu)
                .WithMany(m => m.UserMenus)
                .HasForeignKey(um => um.MenuId);
        }        

    }
}
