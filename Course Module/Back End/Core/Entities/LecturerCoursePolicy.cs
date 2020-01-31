using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class LecturerCoursePolicy
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string Lecture { get; set; }
        public int SemesterCourseId { get; set; }
        [ForeignKey("SemesterCourseId")]
        public SemesterCourse SemesterCourse { get; set; }
        public ICollection<LecturerCoursePolicyDetail> Details { get; set; }
        public LecturerCoursePolicy()
        {
            Details = new List<LecturerCoursePolicyDetail>();
        }
    }
}