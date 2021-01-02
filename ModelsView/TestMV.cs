using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Quizy_API.ModelsView
{
    public class TestMV
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public ICollection<QuestionMV> Questions { get; set; }
    }
}
