using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CoursePolicyDetail
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        public int CoursePolicyId { get; set; }
        [ForeignKey("CoursePolicyId")]
        public CoursePolicy CoursePolicy { get; set; }
    }
}