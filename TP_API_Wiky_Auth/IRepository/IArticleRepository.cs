using DTOs.ArticleDTOs;
using Models;


namespace IRepository
{
    public interface IArticleRepository
    {
        Task<ArticleViewDTO> CreateArticleAsync(Article article);
        Task<ArticleViewDTO> UpdateArticleAsync(Article article);
        Task<bool> DeleteArticleAsync(int articleId);
        Task<List<ArticleViewDTO>> GetAllArticleAsync();
        Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId);
        Task<List<ArticleViewDTO>> GetArticleByDatesAsync(DateTime startDate, DateTime EndDate);
        Task<List<ArticleViewDTO>> GetArticlesByThemeDescAsync();
        Task<List<ArticleViewDTO>> GetArticlesByThemeAscAsync();
        Task<List<ArticleViewDTO>> GetArticlesByAuthorDescAsync();
        Task<List<ArticleViewDTO>> GetArticlesByAuthorAscAsync();
        Task<List<ArticleViewDTO>> GetArticleTop3Async(DateTime date);
        Task<ArticleViewDTO> GetArticleById(int articleId);
    }
}
