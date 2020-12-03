
using System;
using System.Collections.Generic;

namespace Quizy_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}