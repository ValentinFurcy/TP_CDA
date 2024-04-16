using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CONST;
using Repositories.Context;
using System.Reflection.Metadata.Ecma335;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        WikyDbContext _context;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public UserController(WikyDbContext wikyDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = wikyDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Register User
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var today = DateTime.Now.Year;
            var yearUser = userRegisterDTO.DateNaissance.Year;
            var age = today - yearUser;

            if (!string.IsNullOrEmpty(userRegisterDTO.Email) && !string.IsNullOrEmpty(userRegisterDTO.Password) && age > 18)
            {
                try
                {
                    var user = new AppUser { UserName = userRegisterDTO.UserName, Email = userRegisterDTO.Email, DateNaissance = userRegisterDTO.DateNaissance,  };
                    var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

                    if (result.Succeeded)
                    {                        
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Ok("Auth !");
                    }
                    else
                    {
                        return BadRequest("ERROR Try Again");
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Error : {e.Message} ");
                }
            }
            else if (age > 18) 
            {
                return BadRequest("Vous devez avoir au moins 18 ans pour vous inscrire.");
            }
            else return BadRequest("Champs requis non remplis");
        }


        [HttpPost]
        public async Task<IActionResult> CreateRoleAdmin()
        {

            await _roleManager.CreateAsync(new IdentityRole { Name = ROLES.ADMIN, NormalizedName = ROLES.ADMIN });
            await _roleManager.CreateAsync(new IdentityRole { Name = ROLES.USER, NormalizedName = ROLES.USER });

            return Ok();
        }

    }
}

