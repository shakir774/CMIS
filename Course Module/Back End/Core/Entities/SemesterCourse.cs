using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SemesterCourse
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public string CourseCode { get; set; }
        public ICollection<LecturerCoursePolicy> Policies { get; set; }
        public int LecturerId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }
        [ForeignKey("CourseCode")]
        public Course Course { get; set; }
        [ForeignKey("LecturerId")]
        public Lecturer Lecturer { get; set; }
        public SemesterCourse()
        {
            Policies = new List<LecturerCoursePolicy>();
        }
    }
}