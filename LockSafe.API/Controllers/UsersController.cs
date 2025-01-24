using LockSafe.API.Context;
using LockSafe.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly LockSafeContext _context;

        public UsersController(LockSafeContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            // Validação opcional para checar se o e-mail já está em uso
            var emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (emailExists)
            {
                return Conflict(new { message = "E-mail já está em uso." });
            }

            // Adiciona o usuário no banco de dados
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Retorna o usuário criado
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}