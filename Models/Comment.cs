using System;
namespace Quizy_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Rank Rank { get; set; }
        public ApplicationUser User { get; set; }
    }
}