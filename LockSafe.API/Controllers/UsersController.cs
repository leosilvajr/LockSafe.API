using LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LockSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.CreateUser(userDto);
            return Ok("Usuário criado com sucesso!");
        }
    }
}
