using Microsoft.AspNetCore.Mvc;
using restaurant_api.Data;
using restaurant_api.Models;
using restaurant_api.Services;

namespace restaurant_api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(UserModel user)
    {
        user.SenhaHash = BCrypt.Net.BCrypt.HashPassword(user.SenhaHash);
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok("Usuário registrado!");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserModel user)
    {
        var dbUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
        if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.SenhaHash, dbUser.SenhaHash))
            return Unauthorized("Credenciais inválidas!");

        var token = _jwtService.GenerateToken(dbUser);
        return Ok(new { token });
    }
}

