
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CourseLinksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthorizationController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        public UserAuthorizationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserAuthorization
        public async Task<Object> GetUserAuthorization()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }
    }
}