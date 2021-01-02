using System;
namespace Quizy_API.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrue { get; set; }
        
        public Question Question {get; set; }
    }
}