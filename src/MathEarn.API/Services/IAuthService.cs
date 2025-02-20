using MathEarn.API.Models;

namespace MathEarn.API.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
