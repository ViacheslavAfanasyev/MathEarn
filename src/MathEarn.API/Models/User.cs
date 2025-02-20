namespace MathEarn.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required Role Role { get; set; }
        public int? ParentId { get; set; } // Null if Parent
    }
}
