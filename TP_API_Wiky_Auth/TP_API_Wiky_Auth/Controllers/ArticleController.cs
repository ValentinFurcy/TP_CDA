﻿using DTOs.ArticleDTOs;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ArticleController : ControllerBase
    {
        IArticleService _articleService;
        UserManager<AppUser> _userManager;
        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

     
        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="articleDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateDTO articleDTO)
        {

            if (!string.IsNullOrEmpty(articleDTO.Content) && articleDTO.ThemeId > 0)
            {
                var userId = _userManager.GetUserId(User);
                var article = await _articleService.CreateArticleAsync(articleDTO, userId);

                return Ok(article);
            }
            else
            {
                return BadRequest("Unable to create an empty article");
            }
        }

        /// <summary>
        /// Delete Article and Comments if they exist if user it's author or admin
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteArticleAsync(int articleId) 
        {
            if (articleId > 0)
            {

                var user = await _userManager.GetUserAsync(User);

                var isAdmin = await _userManager.IsInRoleAsync(user, "ADMIN");

                var userId = user.Id;

                try
                {
                    bool deleteResult = await _articleService.DeleteArticleAsync(articleId, userId, isAdmin);

                    return Ok(deleteResult);
                }
                catch (MyExceptions e)
                {
                    return BadRequest(e.invalidUser);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"ERROR : {e.Message}");
                }
                             
            }
            else return BadRequest("Enter an ID greater than 0");
        }

        /// <summary>
        /// Update article if user it's author or admin
        /// </summary>
        /// <param name="articleToUpd"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateArticleAsync(ArticleUpdateDTO articleToUpd) 
        {
            if(articleToUpd != null) 
            {
                var user = await _userManager.GetUserAsync(User);

                var isAdmin = await _userManager.IsInRoleAsync(user, "ADMIN");
                
                var userId = user.Id;

                try
                {
                    var article = await _articleService.UpdateArticleAsync(articleToUpd, userId, isAdmin);

                    return Ok(article);
                }              
                catch (MyExceptions e) 
                {
                    return BadRequest(e.invalidUser);
                }
                catch (Exception e)
                {

                    return StatusCode(500, $"ERROR : {e.Message}");
                }
            }
            else return BadRequest("Required fields are not entered");
        }

        /// <summary>
        /// Get All Article
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetAllArticleAsync() 
        {
            try
            {
                var articles = await _articleService.GetAllArticleAsync();
                if (articles.Count > 0)
                {
                    return Ok(articles);
                }
                else return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
           
        }

        /// <summary>
        /// Get Article with they Comments if they existing
        /// </summary>
        /// <param name="articleId">article id</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetArticleAndCommentsAsync(int articleId)
        {
            try
            {
                if(articleId > 0) 
                {
                    var article = await _articleService.GetArticleAndCommentsAsync(articleId);
                    if (article != null)
                    {
                        return Ok(article);
                    }
                    else return NoContent();
                }
               else { return BadRequest("Enter an ID greater than 0"); }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        /// <summary>
        /// Get articles between enter dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate != null && endDate != null )
                {
                    var article = await _articleService.GetArticleByDatesAsync(startDate, endDate);
                    if (article != null)
                    {
                        return Ok(article);
                    }
                    else return NoContent();
                }
                else { return BadRequest("Enter valid dates"); }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesByThemeDescAsync()
        {
            try
            {
                var article = await _articleService.GetArticlesByThemeDescAsync();
                if (article.Any())
                {
                    return Ok(article);
                }
                else return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesByThemeAscAsync()
        {
            try
            {
                var article = await _articleService.GetArticlesByThemeAscAsync();
                if (article.Any())
                {
                    return Ok(article);
                }
                else return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesByAuthorDescAsync()
        {
            try
            {
                var article = await _articleService.GetArticlesByAuthorDescAsync();
                if (article.Any())
                {
                    return Ok(article);
                }
                else return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesByAuthorAscAsync()
        {
            try
            {
                var article = await _articleService.GetArticlesByAuthorAscAsync();
                if (article.Any())
                {
                    return Ok(article);
                }
                else return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArticleTop3Async()
        {
            var date = DateTime.Now;

            try
            {
                if (date != null)
                {
                    var article = await _articleService.GetArticleTop3Async(date);
                    if (article.Any())
                    {
                        return Ok(article);
                    }
                    else return NoContent();
                }
                else { return NotFound("DATE ERROR"); }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }
    }
}
