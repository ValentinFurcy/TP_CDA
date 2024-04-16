using DTOs;
using IRepositories;
using IServices;
using Models;
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

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
           return await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            return await _commentRepository.DeleteCommentAsync(commentId);
        }

        public async Task<List<Comment>> GetCommentByArticleIdAsync(int articleId)
        {
            return await _commentRepository.GetCommentByArticleIdAsync(articleId);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<List<Comment>> GetCommentByUserIdAsync(string userId)
        {
            return await _commentRepository.GetCommentByUserIdAsync(userId);
        }

        public async Task<Comment> UpdateCommentAsync(CommentUpdateDTO commentUpdateDTO)
        {
            if (commentUpdateDTO.Content.Length <= 100)
            {
                Comment comment = new Comment
                {
                    Id = commentUpdateDTO.Id,
                    Content = commentUpdateDTO.Content,
                };
                return await _commentRepository.UpdateCommentAsync(comment);
            }
            else throw new Exception("Commentaire trop long, taille max 100 charactères !");
        }
    }
}
