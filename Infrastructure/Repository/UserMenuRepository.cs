using Application.Interface.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserMenuRepository : IUserMenuRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserMenuRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<Menu>> GetUserMenu(string UserId)
        {
            var UserMenuList = await (from u in _applicationDBContext.UserMenus
                                      join m in _applicationDBContext.Menus on u.MenuId equals m.MenuId
                                      where u.UserId == UserId && u.AccessGranted == true && m.IsDeleted == false
                                      select new Menu()
                                      {
                                          MenuId = m.MenuId,
                                          MenuName = m.MenuName,
                                          ParentMenuId = m.ParentMenuId,
                                          Url = m.Url,
                                          Icon = m.Icon,
                                          IsActive = m.IsActive,
                                          IsDeleted = m.IsDeleted,
                                          Order = m.Order
                                      }).ToListAsync();
            return UserMenuList;
        }
    }
}
