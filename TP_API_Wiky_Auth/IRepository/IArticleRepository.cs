using Models;

namespace IRepository
{
    public interface IArticleRepository
    {
        Task<Article> CreateArticleAsync(Article article);
        Task<Article> UpdateArticleAsync(Article article);
        Task<bool> DeleteArticleAsync(int articleId);
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> GetArticleAndCommentAsync(int articleId);
        Task<List<Article>> GetArticleByDatesAsync(DateTime startDate, DateTime EndDate);
        Task<List<Article>> GetArticlesByThemeDescAsync();
        Task<List<Article>> GetArticlesByThemeAscAsync();
        Task<List<Article>> GetArticlesByAuthorDescAsync();
        Task<List<Article>> GetArticlesByAuthorAscAsync();
        Task<List<Article>> GetArticleTop3Async(DateTime date);

    }
}
