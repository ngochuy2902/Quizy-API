using System;
using System.Collections.Generic;
namespace Quizy_API.Models
{
    public class Test : TrackableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Results { get; set; }
        public Rank Rank { get; set; }
    }
}