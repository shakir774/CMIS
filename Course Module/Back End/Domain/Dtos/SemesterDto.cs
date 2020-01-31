using Core.Enums;

namespace Domain.Dtos
{
    public class SemesterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public SemesterType SemesterType { get; set; }
    }
}