using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CommentDTOs
{
    public class CommentCreateDTO
    {
        [MaxLength(100)]
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
