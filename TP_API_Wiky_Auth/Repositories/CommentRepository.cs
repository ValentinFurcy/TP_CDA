using DTOs.CommentDTOs;
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

        //public async Task<List<CommentDTO>> GetCommentsByArticleIdAsync(int articleId)
        //{
        //    var cDtos = new List<CommentDTO>(); 
        //    //var comments = await _context.Comments.Where(c => c.ArticleId == articleId).ToListAsync();
        //    var commentT = await _context.Comments.Select(c => new { Content = c.Content }).ToListAsync();
        //    foreach (var c in commentT)
        //    {
        //        CommentDTO cDto = new CommentDTO { Content = c.Content };
                
        //        cDtos.Add(cDto);
        //    }
            
        //    if (cDtos.Any())
        //    {
        //        return cDtos;
        //    }
        //    else return null;
        //}

        public async Task<List<CommentCreateDTO>> GetCommentsByArticleIdAsync(int articleId)
        {
         
            //var comments = await _context.Comments.Where(c => c.ArticleId == articleId).ToListAsync();
            var commentT = await _context.Comments.Select(c => new CommentCreateDTO{ Content = c.Content }).ToListAsync();
          

            if (commentT.Any())
            {
                return commentT;
            }
            else return null;
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment != null) { return comment; }
            else return null;
        }

        public async Task<Comment> GetCommentByUserIdAsync(string userId)
        {
            var comment = await _context.Comments.FindAsync(userId);

            if (comment != null)
            {
                return comment;
            }
            else return null;
        }

        public async Task<List<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            var comments = await _context.Comments.Where(c => c.UserId == userId).ToListAsync();

            if (comments.Any())
            {
                return comments;
            }
            else return null;
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
