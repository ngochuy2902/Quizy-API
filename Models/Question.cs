using System;
using System.Collections.Generic;
namespace Quizy_API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int QuestionType {get; set; }
        
        public ICollection<Option> Options { get; set; }
        public Test Test { get; set; }
    }
}