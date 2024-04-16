
using DTOs;
using Models;

namespace IServices
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(ArticleDTO articleDTO);
        Task<Article> UpdateArticleAsync(ArticleUpdateDTO article);
        Task<bool> DeleteArticleAsync(int articleId);
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> GetArticleAndCommentAsync(int articleId);
        Task<List<Article>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate);
        Task<List<Article>> GetArticlesByThemeDescAsync();
        Task<List<Article>> GetArticlesByThemeAscAsync();
        Task<List<Article>> GetArticlesByAuthorDescAsync();
        Task<List<Article>> GetArticlesByAuthorAscAsync();
        Task<List<Article>> GetArticleTop3Async(DateTime date);


    }
}
