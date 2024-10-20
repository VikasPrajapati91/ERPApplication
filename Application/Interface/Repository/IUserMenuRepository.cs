using Domain.Entities;

namespace Application.Interface.Repository
{
    public interface IUserMenuRepository
    {
        Task<List<Menu>> GetUserMenu(string UserId);
    }
}
