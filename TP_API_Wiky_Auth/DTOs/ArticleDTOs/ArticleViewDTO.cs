using Models.CONST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ArticleDTOs
{
    public class ArticleViewDTO
    {
        public string AuthorId { get; set; }
        public string Theme { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
