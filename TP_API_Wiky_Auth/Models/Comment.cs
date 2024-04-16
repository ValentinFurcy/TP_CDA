using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        [MaxLength (100)]
        public string Content { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
