using DTOs.ArticleDTOs;
using Models;

namespace IServices
{
    public interface IArticleService
    {
        Task<ArticleViewDTO> CreateArticleAsync(ArticleCreateDTO articleDTO, string userId);
        Task<ArticleViewDTO> UpdateArticleAsync(ArticleUpdateDTO article, string? userId, bool isAdmin);
        Task<bool> DeleteArticleAsync(int articleId, string userId, bool isAdmin);
        Task<ArticleViewDTO> GetArticleByIdAsync(int articleId);
        Task<List<ArticleViewDTO>> GetAllArticleAsync();
        Task<ArticleAndCommentsDTO> GetArticleAndCommentsAsync(int articleId);
        Task<List<ArticleViewDTO>> GetArticleByDatesAsync(DateTime startDate, DateTime endDate);
        Task<List<ArticleViewDTO>> GetArticlesByThemeDescAsync();
        Task<List<ArticleViewDTO>> GetArticlesByThemeAscAsync();
        Task<List<ArticleViewDTO>> GetArticlesByAuthorDescAsync();
        Task<List<ArticleViewDTO>> GetArticlesByAuthorAscAsync();
        Task<List<ArticleViewDTO>> GetArticleTop3Async(DateTime date);


    }
}
