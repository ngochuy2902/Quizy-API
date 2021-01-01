using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizy_API.ModelsView
{
    public class OptionMV
    {
        public string Answer { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId {get; set; }
    }
}
