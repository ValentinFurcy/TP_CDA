using DTOs.CommentDTOs;
using Models.CONST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ArticleDTOs
{
    public class ArticleAndCommentsDTO : ArticleViewDTO
    {
        public IEnumerable<CommentViewDTO> CommentsViewDTO { get; set; }
    }
}
