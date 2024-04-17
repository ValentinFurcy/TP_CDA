using DTOs.CommentDTOs;
using IRepositories;
using IServices;
using Models;
using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateCommentAsync(CommentCreateDTO commentDTO, string userId)
        {

            Comment comment = new Comment
            {
                Content = commentDTO.Content,
                UserId = userId,
                CreationDate = DateTime.Now,
                ArticleId = commentDTO.ArticleId,
            };

            return await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task<Comment> UpdateCommentAsync(CommentUpdateDTO commentUpdateDTO, string userId, bool isAdmin)
        {
            if (commentUpdateDTO.Content.Length <= 100)
            {
                var verifComment = await _commentRepository.GetCommentByUserIdAsync(userId);

                if (verifComment.UserId == userId || isAdmin)
                {

                    Comment comment = new Comment
                    {
                        Id = commentUpdateDTO.Id,
                        Content = commentUpdateDTO.Content,
                    };
                    return await _commentRepository.UpdateCommentAsync(comment);
                }
                else throw new MyExceptions();
            }
            else throw new Exception("Commentaire trop long, taille max 100 charactères !");
        }

        public async Task<bool> DeleteCommentAsync(int commentId, string userId, bool isAdmin)
        {
            var verifComment = await _commentRepository.GetCommentByUserIdAsync(userId);
            if(verifComment.UserId == userId || isAdmin) 
            {
                return await _commentRepository.DeleteCommentAsync(commentId);
            }
            else throw new MyExceptions();
        }

        public async Task<List<CommentCreateDTO>> GetCommentsByArticleIdAsync(int articleId)
        {
            return await _commentRepository.GetCommentsByArticleIdAsync(articleId);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<Comment> GetCommentByUserIdAsync(string userId)
        {
            return await _commentRepository.GetCommentByUserIdAsync(userId);
        }

        public async Task<List<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            return await _commentRepository.GetCommentsByUserIdAsync(userId);
        }
    }
}
