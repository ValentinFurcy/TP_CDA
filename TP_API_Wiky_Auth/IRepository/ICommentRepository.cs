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
        Task<List<Comment>> GetCommentByArticleIdAsync(int articleId);
        Task<List<Comment>> GetCommentByUserIdAsync(string userId);
    }
}
