using MathEarn.API.Data;
using MathEarn.API.Models;
using MathEarn.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MathEarn.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync<User>(u => u.Email == user.Email))
                return BadRequest("Email already registered.");

            user.PasswordHash = _authService.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser == null || !_authService.VerifyPassword(user.PasswordHash, existingUser.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { Token = token });
        }

        //Should be a separate controller, like UserController
        /*
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("Not specified user email");
            }
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
            if (existingUser == null)
                return NotFound("User doesn't exists");

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();

            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { Token = token });
        }
        */
    }
}
