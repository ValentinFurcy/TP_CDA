using IRepositories;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommentRepository : ICommentRepository
    {

        WikyDbContext _context;
        public CommentRepository(WikyDbContext wikyDbContext)
        {
            _context = wikyDbContext;    
        }
        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comDelete = await _context.Comments.Where(c => c.Id == commentId).ExecuteDeleteAsync();
            if(comDelete > 0) 
            {
                return true;
            }
            else return false;           
        }

        public async Task<List<Comment>> GetCommentByArticleIdAsync(int articleId)
        {
            var comments = await _context.Comments.Where(c => c.ArticleId == articleId).ToListAsync();

            if (comments.Any())
            {
                return comments;
            }
            else throw new Exception("Aucun commentaire trouvé");
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment != null) { return comment; }
            else throw new Exception("Aucun commentaire trouvé");
        }

        public async Task<List<Comment>> GetCommentByUserIdAsync(string userId)
        {
            var comments = await _context.Comments.Where(c => c.UserId == userId).ToListAsync();

            if (comments.Any())
            {
                return comments;
            }
            else throw new Exception("Aucun commentaire trouvé");
        }
        public async Task<Comment> UpdateCommentAsync(Comment comment)
        {
            try
            {
                var nbRows = await _context.Comments.Where(c => c.Id == comment.Id).ExecuteUpdateAsync(
                    updates => updates.SetProperty(c => c.Content, comment.Content)                        
                            .SetProperty(c => c.ModificationDate, comment.ModificationDate)                          
                    );
                if (nbRows > 0)
                {
                    return comment;
                }
                throw new Exception("La modification a échouée");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
