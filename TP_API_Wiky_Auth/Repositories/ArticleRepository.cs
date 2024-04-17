using DTOs.ArticleDTOs;
using DTOs.CommentDTOs;
using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        WikyDbContext _context;

        public ArticleRepository(WikyDbContext wikyDbContext)
        {
            _context = wikyDbContext;
        }
        public async Task<Article> CreateArticleAsync(Article article)
        {    
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                return article;
        }

        public async Task<Article> GetArticleById(int articleId)
        {
           var article = await _context.Articles.FindAsync(articleId);
            if (article != null) { return article; }
            else return null;
            
        }
        public async Task<Article> UpdateArticleAsync(Article article)
        {
            try
            {
                var nbRows = await _context.Articles.Where(a => a.Id == article.Id).ExecuteUpdateAsync(
                    updates => updates.SetProperty(a => a.Content, article.Content)
                            .SetProperty(a => a.ModificationDate, article.ModificationDate)
                            .SetProperty(a => a.ThemeId, article.ThemeId)
                    );
                if (nbRows > 0)
                {
                    return article;
                }
                throw new Exception("La modification a échouée");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<bool> DeleteArticleAsync(int articleId)
        {
           using (var transaction = _context.Database.BeginTransaction()) 
            {
                try
                {
                    var comment = await _context.Comments.Where(c => c.ArticleId == articleId).ExecuteDeleteAsync();
                    var article = await _context.Articles.Where(a => a.Id == articleId).ExecuteDeleteAsync();

                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<List<Article>> GetAllArticleAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId)
        {
            var article = await _context.Articles.Include(a => a.Theme)
                .Include(a => a.Comments).ThenInclude(c => c.User)
                .Include(a => a.User)
                .Where(a => a.Id == articleId)
                .Select(a => new ArticleAndCommentsDTO
                {
                    Author = a.User.UserName,
                    Content = a.Content,
                    Theme = a.Theme.Label,
                    CommentsViewDTO = a.Comments.Select(c => new CommentViewDTO { Author = c.User.UserName, Content = c.Content })

                }).FirstOrDefaultAsync();

            if (article != null)
            {
                return article;
            }
            else return null;
        }

        public async Task<List<Article>> GetArticlesByAuthorAscAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderBy(a => a.User).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<List<Article>> GetArticlesByAuthorDescAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.User).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<List<Article>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).Where(a => a.CreationDate >= startDate && a.CreationDate <= endDate).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<List<Article>> GetArticlesByThemeAscAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderBy(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<List<Article>> GetArticlesByThemeDescAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        public async Task<List<Article>> GetArticleTop3Async(DateTime date)
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.ModificationDate ?? a.CreationDate).Take(3).ToListAsync();
            if (articles.Any())
            {
                return articles;
            }
            else return new List<Article>();
        }

        
    }
}
