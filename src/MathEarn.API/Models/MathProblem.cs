namespace MathEarn.API.Models
{
    public class MathProblem
    {
        public int Id { get; set; }
        public required string Question { get; set; }
        public double Answer { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
    }
}
