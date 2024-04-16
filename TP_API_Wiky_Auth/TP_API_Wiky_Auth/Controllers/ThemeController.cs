using DTOs;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CONST;
using Services;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = ROLES.ADMIN)]
    public class ThemeController : ControllerBase
    {
        IThemeService _themeService;
        public ThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheme(ThemeDTO themeDTO) 
        {
            if (!string.IsNullOrEmpty(themeDTO.Label))
            {
                try
                {
                    var theme = await _themeService.CreateThemeAsync(themeDTO);
                    return Ok($"theme : {theme.Label}");
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"ERROR : {e.Message}");
                }
            }
            else return BadRequest("Il Faut un nom au theme !");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTheme() 
        {
            var themes = await _themeService.GetAllThemeAsync();
            if (themes.Any()) 
            {
                return Ok(themes);
            }
            else { return NoContent(); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTheme(ThemeUpdateDTO themeUpdateDTO) 
        {
            if (themeUpdateDTO != null)
            {
                var theme = await _themeService.UpdateThemeAsync(themeUpdateDTO);

                if (theme != null)
                {
                    return Ok(theme);
                }
                else { return NotFound(); }
            }
            else return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment(int themeId) 
        {
            if (themeId > 0)
            {
                return await _themeService.DeleteThemeAsync(themeId);
            }
            else return BadRequest("Saisir un ID supérieur à 0");
        }
    }
}
