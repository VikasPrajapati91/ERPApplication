using Application.Interface.Repository;
using Application.Interface.Service;
using Domain.Entities;

namespace Application.Service
{
    public class UserMenuService : IUserMenuService
    {
        private readonly IUserMenuRepository _iUserMenuRepository;
        public UserMenuService(IUserMenuRepository iUserMenuRepository)
        {
            _iUserMenuRepository = iUserMenuRepository;
        }

        public async Task<List<Menu>> GetUserMenu(string UserId)
        {
            return await _iUserMenuRepository.GetUserMenu(UserId);
        }
    }
}
