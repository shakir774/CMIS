using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CoursePolicy
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string CourseCode { get; set; }
        public string Lecture { get; set; }
        [ForeignKey("CourseCode")]
        public Course Course { get; set; }
        public ICollection<CoursePolicyDetail> Details { get; set; }
        public CoursePolicy()
        {
            Details = new List<CoursePolicyDetail>();
        }
    }
}