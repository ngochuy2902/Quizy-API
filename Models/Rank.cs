using System;
using System.Collections.Generic;
namespace Quizy_API.Models
{
    public class Rank
    {
        public int Id { get; set; }
        
        public int TestId {get; set; }
        public Test Test { get; set; }
        public ICollection<Result> Results {get; set; }
        public ICollection<Comment> Comments {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    } 
}