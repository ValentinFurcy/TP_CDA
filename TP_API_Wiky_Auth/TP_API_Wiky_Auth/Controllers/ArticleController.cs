using DTOs;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ArticleController : ControllerBase
    {
        IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleDTO articleDTO)
        {

            if (!string.IsNullOrEmpty(articleDTO.Author) && !string.IsNullOrEmpty(articleDTO.Content) && articleDTO.ThemeId > 0)
            {
                var article = await _articleService.CreateArticleAsync(articleDTO);

                return Ok($"créé ! : {article.Content}");
            }
            else
            {
                return BadRequest("Impossible de créer un article vide");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteArticleAsync(int articleId) 
        {
            if (articleId > 0)
            {
                return await _articleService.DeleteArticleAsync(articleId);
            }
            else return BadRequest("Saisir un ID supérieur à 0");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticleAsync(ArticleUpdateDTO articleToUpd) 
        {
            if(articleToUpd != null) 
            {
                var article = await _articleService.UpdateArticleAsync(articleToUpd);

                return Ok($"modification : {article}");
            }
            else return BadRequest("Champs requis non renseignés");
        }

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

        [HttpGet]
        public async Task<IActionResult> GetArticleAndCommentAsync(int articleId)
        {
            try
            {
                if(articleId > 0) 
                {
                    var article = await _articleService.GetArticleAndCommentAsync(articleId);
                    if (article != null)
                    {
                        return Ok(article);
                    }
                    else return NoContent();
                }
               else { return BadRequest("Veuillez saisir un Id supérieur à 0"); }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }

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
                else { return BadRequest("Veuillez saisir des dates valides"); }
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
        public async Task<IActionResult> GetArticleTop3Async(DateTime date)
        {
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
                else { return BadRequest("Veuillez saisir une date valide"); }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"ERROR : {e.Message}");
            }
        }
    }
}
