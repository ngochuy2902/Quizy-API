using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizy_API.ModelsView
{
    public class CommentMV
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
    }
}
