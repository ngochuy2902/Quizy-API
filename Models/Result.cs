using System;
namespace Quizy_API.Models
{
    public class Result : TrackableEntity
    {
        public int Id { get; set; }
        public double Scored { get; set; }

        public Test Test { get; set; }
        public ApplicationUser User { get; set; } 
    }
}