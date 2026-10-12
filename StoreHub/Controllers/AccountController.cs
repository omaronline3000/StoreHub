using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreHub.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

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
        public async Task<IActionResult> Register(UserDTO UserFromReq)
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
            return BadRequest(ModelState); // which state should i return with
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTO UserfromReq)
        {
            var appUser = await _userManager.FindByNameAsync(UserfromReq.UserName);
            if(appUser is not null)
            {
                bool res = await _userManager.CheckPasswordAsync(appUser, UserfromReq.Password);
                if (res)
                {

                    // Token Design

                    // Claims
                    List<Claim> Claims = new();
                    Claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
                    Claims.Add(new Claim(ClaimTypes.Name, appUser.UserName!));
                    Claims.Add(new Claim(ClaimTypes.Role, "Guest"));
                    Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


                    // Verfication requirements
                    SymmetricSecurityKey key = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configure["JWT:SecretKey"])
                        );


                    SigningCredentials cred = new SigningCredentials(
                        algorithm: SecurityAlgorithms.HmacSha256,
                        key: key
                        );


                      // Token Creation
                    JwtSecurityToken jwt = new JwtSecurityToken(
                        issuer: _configure["JWT:Issuer"],
                        audience: _configure["JWT:Audience"],
                        claims: Claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: cred

                        );

                    // Generate and Return the Token
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwt),
                        expirationDateInHourse = _configure.GetValue<int>("JWT:ExpiratoinInHourse")
                    });

                }

            }
            ModelState.AddModelError("", "UserName or Password is wrong");
            return BadRequest(ModelState); // Which stat should i return with


        }


    }
}
