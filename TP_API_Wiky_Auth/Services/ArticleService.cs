using DTOs.ArticleDTOs;
using IRepository;
using IServices;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<ArticleViewDTO> CreateArticleAsync(ArticleCreateDTO articleDTO, string userId)
        {
            
            Article article = new Article
            {
                UserId = userId,
                Content = articleDTO.Content,
                CreationDate = DateTime.Now,
                ThemeId = articleDTO.ThemeId,
                Priority = articleDTO.Priority,
            };

            return await _articleRepository.CreateArticleAsync(article);
        }

        public async Task<ArticleViewDTO> GetArticleByIdAsync(int articleId)
        {
            return await _articleRepository.GetArticleById(articleId);
        }

        public async Task<ArticleViewDTO> UpdateArticleAsync(ArticleUpdateDTO articleToUpdate, string? userId, bool isAdmin)
        {
            
            var verifArticle = await GetArticleByIdAsync(articleToUpdate.Id); 
           

            if (verifArticle.AuthorId == userId || isAdmin)
            {
                Article article = new Article
                {
                    Id = articleToUpdate.Id,
                    Content = articleToUpdate.Content,
                    ThemeId = articleToUpdate.ThemeId,
                    ModificationDate = DateTime.Now,
                };

                return await _articleRepository.UpdateArticleAsync(article);
            }
            else throw new MyExceptions();
        }

        public async Task<bool> DeleteArticleAsync(int articleId, string userId, bool isAdmin)
        {
            var verifArticle = await GetArticleByIdAsync(articleId);
            if(verifArticle.AuthorId == userId ||isAdmin) 
            {
                return await _articleRepository.DeleteArticleAsync(articleId);
            }
            else throw new MyExceptions();
        }

        public async Task<List<ArticleViewDTO>> GetAllArticleAsync()
        {
           return await _articleRepository.GetAllArticleAsync();
        }

        public async Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId)
        {
            return await _articleRepository.GetArticleAndCommentsAsync(articleId);
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByAuthorAscAsync()
        {
                return await _articleRepository.GetArticlesByAuthorAscAsync();
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByAuthorDescAsync()
        {
            return await _articleRepository.GetArticlesByThemeDescAsync();
        }

        public async Task<List<ArticleViewDTO>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _articleRepository.GetArticleByDatesAsync(startDate, endDate);
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByThemeAscAsync()
        {
            return await _articleRepository.GetArticlesByThemeAscAsync();
        }

        public async Task<List<ArticleViewDTO>> GetArticlesByThemeDescAsync()
        {
            return await _articleRepository.GetArticlesByThemeDescAsync();
        }

        public async Task<List<ArticleViewDTO>> GetArticleTop3Async(DateTime date)
        {
            return await _articleRepository.GetArticleTop3Async(date);
        }

  
    }
}
