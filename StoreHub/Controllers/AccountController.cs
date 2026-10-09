using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreHub.Models;
using System.Runtime.CompilerServices;

namespace StoreHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configure;
        public AccountController(UserManager<ApplicationUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configure = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO UserFromReq)
        {
            ApplicationUser appUser = new() { UserName = UserFromReq.UserName };
            var res = await _userManager.CreateAsync(appUser, UserFromReq.Password);
            if (res.Succeeded)
            {
                return Created();
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return BadRequest(ModelState);
        }

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login()
        //{

        //}


    }
}
