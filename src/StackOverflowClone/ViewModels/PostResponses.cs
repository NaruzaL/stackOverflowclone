using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverflowClone.Models;


namespace StackOverflowClone.ViewModels
{
    public class PostResponses
    {
        public List<Response> responses { get; set; }
        public Post Post { get; set; }
    }
}
