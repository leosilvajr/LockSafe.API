using LockSafe.Application.DTOs;
using LockSafe.Application.DTOs.LockSafe.Application.DTOs;
using LockSafe.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LockSafe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public LoginController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.UserName == "string" && loginDto.Password == "string")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                // Gerar o JWT
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Usuario = loginDto.UserName, Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
