using Models.CONST;

namespace DTOs.ArticleDTOs
{
    public class ArticleCreateDTO
    {
        public string Content { get; set; }
        public Priority Priority { get; set; }
        public int ThemeId { get; set; }
    }
}

