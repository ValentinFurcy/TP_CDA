using Models.CONST;

namespace DTOs
{
    public class ArticleDTO
    {
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Content { get; set; }
        public Priority Priority { get; set; }
        public int ThemeId { get; set; }
    }
}

