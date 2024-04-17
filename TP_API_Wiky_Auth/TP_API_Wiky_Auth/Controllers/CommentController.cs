using DTOs.CommentDTOs;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;
using Services;
using System.ComponentModel.Design;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        /// <summary>
        /// Create comment for article
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDTO commentDTO)
        {
          
            if (!string.IsNullOrEmpty(commentDTO.Content))
            {
                var userId = _userManager.GetUserId(User);
                var comment = await _commentService.CreateCommentAsync(commentDTO, userId);

                return Ok($"créé ! : {comment.Content}");
            }
            else
            {
                return BadRequest("Impossible de créer un article vide");
            }
        }

        /// <summary>
        /// Update comment if user it's author or admin 
        /// </summary>
        /// <param name="commentUpdateDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentUpdateDTO commentUpdateDTO) 
        {

            if(!string.IsNullOrEmpty(commentUpdateDTO.Content)) 
            {
                var user = await _userManager.GetUserAsync(User);

                var isAdmin = await _userManager.IsInRoleAsync(user, "ADMIN");

                var userId = user.Id;

                try
                {
                    var comment = await _commentService.UpdateCommentAsync(commentUpdateDTO, userId, isAdmin);
                }
                catch (MyExceptions e) 
                {
                    return BadRequest(e.invalidUser);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"ERROR : {e.Message}");
                }

                await _commentService.UpdateCommentAsync(commentUpdateDTO, userId, isAdmin);

                return Ok(commentUpdateDTO.Content);
            }
            return BadRequest("Champs requis non renseignés");
        }

        /// <summary>
        /// Delete comment if user it's author or admin
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment(int commentId)
        {
            if (commentId > 0)
            {
                var user = await _userManager.GetUserAsync(User);

                var isAdmin = await _userManager.IsInRoleAsync(user, "ADMIN");

                var userId = user.Id;

                try
                {
                    bool deleteResult = await _commentService.DeleteCommentAsync(commentId, userId, isAdmin);
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
            else return BadRequest("Saisir un ID supérieur à 0");
        }

        /// <summary>
        /// Get Comment by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCommentsByUserId(string userId) 
        {
            if (!string.IsNullOrEmpty(userId) )
            {
                var comments = await _commentService.GetCommentsByUserIdAsync(userId);
                if (comments.Any()) 
                {
                    return Ok(comments);
                }
                else return NotFound();
            }
            else return BadRequest("Saisir un ID supérieur à 0");
        }
        
    }
}
