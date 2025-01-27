using LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PasswordController : ControllerBase
{
    private readonly IPasswordService _passwordService;

    public PasswordController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePassword([FromBody] PasswordCreateDTO passwordDto)
    {
        // Aqui vamos Precisar recuparar o Id do Usuario Autenticado para criar o registro de senha.
        var userId = 0;

        if (userId == 0)
            return Unauthorized(new { Message = "Usuário não autenticado." });

        var createdPassword = await _passwordService.CreatePasswordAsync(passwordDto, userId);

        return CreatedAtAction(nameof(CreatePassword), new { id = createdPassword.Id }, createdPassword);
    }
}
