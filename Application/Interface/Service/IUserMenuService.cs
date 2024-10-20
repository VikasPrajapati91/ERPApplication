using Domain.Entities;

namespace Application.Interface.Service
{
    public interface IUserMenuService
    {
        Task<List<Menu>> GetUserMenu(string UserId);
    }
}
