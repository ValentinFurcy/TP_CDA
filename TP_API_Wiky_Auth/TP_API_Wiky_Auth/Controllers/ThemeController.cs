using DTOs.ThemeDTOs;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Models;
using Models.CONST;
using Services;

namespace TP_API_Wiky_Auth.Controllers
{
    /// <summary>
    /// Controller reserved for ADMIN
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = ROLES.ADMIN)]
    public class ThemeController : ControllerBase
    {
        IThemeService _themeService;
        public ThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        /// <summary>
        /// Create theme reserved for ADMIN
        /// </summary>
        /// <param name="themeDTO">object themeDTO</param>
        /// <returns></returns>
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

        /// <summary>
        /// GetAll theme reserved for ADMIN
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Update Theme reserved for ADMIN
        /// </summary>
        /// <param name="themeUpdateDTO">object themeUpdateDTO</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPut]
        public async Task<IActionResult> UpdateTheme(ThemeDTO themeUpdateDTO) 
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

        /// <summary>
        /// Delete Theme reserved for ADMIN / return true if the deletion was success or false if the deletion unsuccess
        /// </summary>
        /// <param name="themeId">id theme</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool) , StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
       
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTheme(int themeId) 
        {
            if (themeId > 0)
            {
                return await _themeService.DeleteThemeAsync(themeId);
            }
            else return BadRequest("Saisir un ID supérieur à 0");
        }
    }
}
