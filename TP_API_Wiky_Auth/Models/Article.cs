using Models.CONST;

namespace Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Content { get; set; }
        public Priority Priority { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public List<Comment>? Comments { get; set;}
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
