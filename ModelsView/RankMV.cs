using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizy_API.ModelsView
{
    public class RankMV
    {
        public int Id { get; set; }
        public ICollection<ResultMV> Results {get; set; }
        public ICollection<CommentMV> Comments {get; set; }
    }
}
