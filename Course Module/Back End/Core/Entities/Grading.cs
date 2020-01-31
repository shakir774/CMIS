using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Grading
    {
        public int Id { get; set; }
        public int Assignment { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Project { get; set; }
    }
}