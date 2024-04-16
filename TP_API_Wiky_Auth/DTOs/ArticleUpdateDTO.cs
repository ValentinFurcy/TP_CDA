using Models.CONST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ArticleUpdateDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Priority Priority { get; set; }
        public int ThemeId { get; set; }
    }
}
