using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Entities
{
    public class SemesterStudent
    {
        public int SemesterId { get; set; }
        public int StudentId { get; set; }
        public StudentType StudentType { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }
    }
}