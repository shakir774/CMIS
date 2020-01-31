using System.Collections.Generic;
using Core.Entities;

namespace Domain.Dtos
{
    public class CoursePolicyDto
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string CourseCode { get; set; }
        public string Lecture { get; set; }
        public ICollection<CoursePolicyDetail> Details { get; set; }
    }
}