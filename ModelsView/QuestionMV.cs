using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizy_API.ModelsView
{
    public class QuestionMV
    {
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int QuestionType {get; set; }
        
        public ICollection<OptionMV> Options { get; set; }
        public int TestId { get; set; }
    }
}
