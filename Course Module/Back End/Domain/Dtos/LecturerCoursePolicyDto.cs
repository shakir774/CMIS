using System.Collections.Generic;
using Core.Entities;

namespace Domain.Dtos
{
    public class LecturerCoursePolicyDto
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string Lecture { get; set; }
        public int SemesterCourseId { get; set; }
        public ICollection<LecturerCoursePolicyDetail> Details { get; set; }
    }
}