using System;
namespace Quizy_API.Models
{
    public class Comment : TrackableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Rank Rank { get; set; }
        public ApplicationUser User { get; set; }
    }
}