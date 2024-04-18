using DTOs.UserDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.CONST;
using Repositories.Context;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;

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
        /// Register User with role User
        /// </summary>
        /// /// <param name="userRegisterDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var dateToday = DateTime.Now;           
            var ageUser = userRegisterDTO.BirthDate;
         
            if (!string.IsNullOrEmpty(userRegisterDTO.Email) && !string.IsNullOrEmpty(userRegisterDTO.Password) && ageUser.AddYears(18) < dateToday)
            {
                try
                {
                    var user = new AppUser { UserName = userRegisterDTO.UserName, Email = userRegisterDTO.Email, BirthDate = DateOnly.FromDateTime(userRegisterDTO.BirthDate),  };
                    var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, ROLES.USER);
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
            else if (ageUser.AddYears(18) > dateToday) 
            {
                return BadRequest("Vous devez avoir au moins 18 ans pour vous inscrire.");
            }
            else return BadRequest("Champs requis non remplis");
        }

        /// <summary>
        /// Create Role if not existing
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> CreateRole()
        {
            if (!await _roleManager.RoleExistsAsync(ROLES.ADMIN) || !await _roleManager.RoleExistsAsync(ROLES.USER))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = ROLES.ADMIN, NormalizedName = ROLES.ADMIN });

                await _roleManager.CreateAsync(new IdentityRole { Name = ROLES.USER, NormalizedName = ROLES.USER });

                return Ok();
            }    
            else
            {
                var existingRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return BadRequest($"Les rôles existants sont : {string.Join(", ", existingRoles)}");
            }
            
        }

        /// <summary>
        /// Create User with Role Admin
        /// </summary>
        /// <param name="userRegisterDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(UserRegisterDTO userRegisterDTO) 
        {
            var dateToday = DateTime.Now;
            var ageUser = userRegisterDTO.BirthDate;

            if (!string.IsNullOrEmpty(userRegisterDTO.Email) && !string.IsNullOrEmpty(userRegisterDTO.Password) && ageUser.AddYears(18) < dateToday)
            {
                try
                {
                    var user = new AppUser { UserName = userRegisterDTO.UserName, Email = userRegisterDTO.Email, BirthDate = DateOnly.FromDateTime(userRegisterDTO.BirthDate), };
                    var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);
                    

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, ROLES.ADMIN);
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
            else if (ageUser.AddYears(18) > dateToday)
            {
                return BadRequest("Vous devez avoir au moins 18 ans pour vous inscrire.");
            }
            else return BadRequest("Champs requis non remplis");
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout() 
        { 
            await _signInManager.SignOutAsync();

            return Ok("You Is disconnect");
        }
    }
}

