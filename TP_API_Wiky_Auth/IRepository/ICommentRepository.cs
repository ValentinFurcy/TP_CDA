using DTOs.CommentDTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface ICommentRepository
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment> UpdateCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<List<CommentCreateDTO>> GetCommentsByArticleIdAsync(int articleId);
        Task<List<Comment>> GetCommentsByUserIdAsync(string userId);
        Task<Comment> GetCommentByUserIdAsync(string userId);

    }
}
