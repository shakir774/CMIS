namespace Domain.Dtos
{
    public class GradingDto
    {
        public int Id { get; set; }
        public int Assignment { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Project { get; set; }
    }
}