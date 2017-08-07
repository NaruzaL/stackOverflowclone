using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowClone.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
        public int Vote { get; set; }
        public bool BestAnswer { get; set; }
        public DateTime ResponseDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }

    }
}
