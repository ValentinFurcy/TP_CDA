using DTOs;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.ComponentModel.Design;

namespace TP_API_Wiky_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDTO commentDTO)
        {
          
            if (!string.IsNullOrEmpty(commentDTO.Content))
            {
                var user = await _userManager.GetUserAsync(User);

                Comment comment = new Comment
                {
                    Content = commentDTO.Content,
                    Author = user.UserName,
                    UserId = user.Id,
                    CreationDate = DateTime.Now,
                    ArticleId = commentDTO.ArticleId,
                };
                await _commentService.CreateCommentAsync(comment);

                return Ok($"créé ! : {comment.Content}");
            }
            else
            {
                return BadRequest("Impossible de créer un article vide");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentUpdateDTO commentUpdateDTO) 
        {
            if(!string.IsNullOrEmpty(commentUpdateDTO.Content)) 
            {
                await _commentService.UpdateCommentAsync(commentUpdateDTO);

                return Ok(commentUpdateDTO.Content);
            }
            return BadRequest("Champs requis non renseignés");
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment(int commentId)
        {
            if (commentId > 0)
            {
                return await _commentService.DeleteCommentAsync(commentId);
            }
            else return BadRequest("Saisir un ID supérieur à 0");
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentByUserId(string userId) 
        {
            if (!string.IsNullOrEmpty(userId) )
            {
                var comments = await _commentService.GetCommentByUserIdAsync(userId);
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
