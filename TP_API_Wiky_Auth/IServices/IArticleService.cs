using DTOs.ArticleDTOs;
using Models;

namespace IServices
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(ArticleDTO articleDTO, string userId);
        Task<Article> UpdateArticleAsync(ArticleUpdateDTO article, string? userId, bool isAdmin);
        Task<bool> DeleteArticleAsync(int articleId, string userId, bool isAdmin);
        Task<Article> GetArticleByIdAsync(int articleId);
        Task<List<Article>> GetAllArticleAsync();
        Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId);
        Task<List<Article>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate);
        Task<List<Article>> GetArticlesByThemeDescAsync();
        Task<List<Article>> GetArticlesByThemeAscAsync();
        Task<List<Article>> GetArticlesByAuthorDescAsync();
        Task<List<Article>> GetArticlesByAuthorAscAsync();
        Task<List<Article>> GetArticleTop3Async(DateTime date);


    }
}
