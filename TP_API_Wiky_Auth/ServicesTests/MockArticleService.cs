using DTOs.ArticleDTOs;
using IServices;
using Models;
using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests
{
    public class MockArticleService : IArticleService
    {
        public Task<ArticleViewDTO> CreateArticleAsync(ArticleCreateDTO articleDTO, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteArticleAsync(int articleId, string userId, bool isAdmin)
        {
            ArticleViewDTO verifArticle = new ArticleViewDTO { AuthorId = "10" };

            if (verifArticle.AuthorId == userId || isAdmin)
            {
                return true;
            }
            else throw new MyExceptions();
        }

        public Task<List<ArticleViewDTO>> GetAllArticleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleViewDTO> GetArticleByIdAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticlesByAuthorAscAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticlesByAuthorDescAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticlesByThemeAscAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticlesByThemeDescAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleViewDTO>> GetArticleTop3Async(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleViewDTO> UpdateArticleAsync(ArticleUpdateDTO article, string? userId, bool isAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
