using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Core.Enums;

namespace Core.Entities
{
    public class Course
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Prerequisite { get; set; }
        public string Description { get; set; }
        public ICollection<CoursePolicy> Policies { get; set; }
        [ForeignKey("GradingId")]
        public Grading Grading { get; set; }
        public int GradingId { get; set; }
        public CourseType CourseType { get; set; }

        public Course()
        {
            Policies = new List<CoursePolicy>();
        }
    }
}