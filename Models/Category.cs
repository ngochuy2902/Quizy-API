
using System;
using System.Collections.Generic;

namespace Quizy_API.Models
{
    public class Category : TrackableEntity
    {
        public int Id { get; set; }
        public string Name {get; set; }
        
        public ICollection<Test> Tests { get; set; }
    }
}