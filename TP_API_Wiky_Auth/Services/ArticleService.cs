using DTOs;
using IRepository;
using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class ArticleService : IArticleService
    {
        IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<Article> CreateArticleAsync(ArticleDTO articleDTO)
        {
            Article article = new Article 
            { 
                Author = articleDTO.Author,
                Content = articleDTO.Content,
                CreationDate = DateTime.Now,
                ThemeId = articleDTO.ThemeId,
                Priority = articleDTO.Priority,
            };

            return await _articleRepository.CreateArticleAsync(article);
        }

        public async Task<Article> UpdateArticleAsync(ArticleUpdateDTO articleToUpdate)
        {
            Article article = new Article
            {
                Id = articleToUpdate.Id,
                Content = articleToUpdate.Content,
                ThemeId = articleToUpdate.ThemeId,
                Priority = articleToUpdate.Priority,
                ModificationDate = DateTime.Now,
            };
            return await _articleRepository.UpdateArticleAsync(article);
        }
        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            return await _articleRepository.DeleteArticleAsync(articleId);
        }

        public async Task<List<Article>> GetAllArticleAsync()
        {
           return await _articleRepository.GetAllArticleAsync();
        }

        public async Task<Article> GetArticleAndCommentAsync(int articleId)
        {
            return await _articleRepository.GetArticleAndCommentAsync(articleId);
        }

        public async Task<List<Article>> GetArticlesByAuthorAscAsync()
        {
                return await _articleRepository.GetArticlesByAuthorAscAsync();
        }

        public async Task<List<Article>> GetArticlesByAuthorDescAsync()
        {
            return await _articleRepository.GetArticlesByThemeDescAsync();
        }

        public async Task<List<Article>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _articleRepository.GetArticleByDatesAsync(startDate, endDate);
        }

        public async Task<List<Article>> GetArticlesByThemeAscAsync()
        {
            return await _articleRepository.GetArticlesByThemeAscAsync();
        }

        public async Task<List<Article>> GetArticlesByThemeDescAsync()
        {
            return await _articleRepository.GetArticlesByThemeDescAsync();
        }

        public async Task<List<Article>> GetArticleTop3Async(DateTime date)
        {
            return await _articleRepository.GetArticleTop3Async(date);
        }
    }
}
