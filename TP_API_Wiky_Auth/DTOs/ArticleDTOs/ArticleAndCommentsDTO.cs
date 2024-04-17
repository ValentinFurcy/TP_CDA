using DTOs.CommentDTOs;
using Models.CONST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ArticleDTOs
{
    public class ArticleAndCommentsDTO 
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public Priority Priority { get; set; }
        public string Theme { get; set; }

        public IEnumerable<CommentViewDTO> CommentsViewDTO { get; set; }
    }
}
