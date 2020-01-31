using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class LecturerCoursePolicyDetail
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        public int LecturerCoursePolicyId { get; set; }
        [ForeignKey("LecturerCoursePolicyId")]
        public LecturerCoursePolicy LecturerCoursePolicy { get; set; }
    }
}