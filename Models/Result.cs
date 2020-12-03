using System;
namespace Quizy_API.Models
{
    public class Result
    {
        public int Id { get; set; }
        public double Scored { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Test Test { get; set; }
        public ApplicationUser User { get; set; } 
    }
}