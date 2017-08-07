using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowClone.Models
{   
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public int PostVote { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Response> Answers { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
