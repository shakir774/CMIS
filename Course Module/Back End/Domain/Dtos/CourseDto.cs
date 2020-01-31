using System.Collections.Generic;
using Core.Entities;
using Core.Enums;

namespace Domain.Dtos
{
    public class CourseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Prerequisite { get; set; }
        public string Description { get; set; }
        public ICollection<CoursePolicy> Policies { get; set; }
        public int GradingId { get; set; }
        public CourseType CourseType { get; set; }
    }
}