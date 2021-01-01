using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizy_API.ModelsView
{
    public class ResultMV
    {
        public double Scored { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TestId { get; set; }
        public string UserName { get; set; } 
    }
}
