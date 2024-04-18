using AutoMapper;
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
        IMapper _mapper;
        public ArticleRepository(IMapper mapper, WikyDbContext wikyDbContext)
        {
            _mapper = mapper;
            _context = wikyDbContext;
        }
        public async Task<ArticleViewDTO> CreateArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ArticleViewDTO>(article);

            return result;
        }

        public async Task<ArticleViewDTO> GetArticleById(int articleId)
        {
            var article = await _context.Articles.FindAsync(articleId);

            if (article != null) 
            {
                var result = _mapper.Map<ArticleViewDTO>(article);

                return result; 
            }
            else return null;
            
        }
        public async Task<ArticleViewDTO> UpdateArticleAsync(Article article)
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
                    var result = _mapper.Map<ArticleViewDTO>(article);

                    return result;
                   
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

        public async Task<List<ArticleViewDTO>> GetAllArticleAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
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

        public async Task<List<ArticleViewDTO>> GetArticlesByAuthorAscAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderBy(a => a.User).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByAuthorDescAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.User).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        public async Task<List<ArticleViewDTO>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).Where(a => a.CreationDate >= startDate && a.CreationDate <= endDate).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByThemeAscAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderBy(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByThemeDescAsync()
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.Theme).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        public async Task<List<ArticleViewDTO>> GetArticleTop3Async(DateTime date)
        {
            var articles = await _context.Articles.Include(a => a.Theme).Include(a => a.Comments).OrderByDescending(a => a.ModificationDate ?? a.CreationDate).Take(3).ToListAsync();
            if (articles.Any())
            {
                var result = _mapper.Map<List<ArticleViewDTO>>(articles);

                return result;
            }
            else return new List<ArticleViewDTO>();
        }

        
    }
}
