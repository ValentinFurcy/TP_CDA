using DTOs.CommentDTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(CommentCreateDTO commentDTO, string userId);
        Task<Comment> UpdateCommentAsync(CommentUpdateDTO commentUpdateDTO, string userId, bool isAdmin);
        Task<bool> DeleteCommentAsync(int commentId, string userId, bool isAdmin);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<List<CommentCreateDTO>>GetCommentsByArticleIdAsync(int articleId);
        Task<List<Comment>> GetCommentsByUserIdAsync(string userId);
        Task<Comment> GetCommentByUserIdAsync(string userId);

    }
}
