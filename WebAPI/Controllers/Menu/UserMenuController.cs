using Application.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMenuController: ControllerBase
    {
        private readonly IUserMenuService _userMenuService;
        public UserMenuController(IUserMenuService userMenuService)
        {
            _userMenuService = userMenuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMenu(string UserId)
        {
            var UserMenuList = await _userMenuService.GetUserMenu(UserId);
            return Ok(UserMenuList);
        }
    }
}
