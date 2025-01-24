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

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = new List<Users>
                    {
                        new Users
                        {
                            Id = 1,
                            FullName = "Test User 1",
                            UserName = "testuser1",
                            Email = "test1@example.com",
                            Password = "password1",
                            ProfileImageUrl = "https://example.com/image1.png"
                        },
                        new Users
                        {
                            Id = 2,
                            FullName = "Test User 2",
                            UserName = "testuser2",
                            Email = "test2@example.com",
                            Password = "password2",
                            ProfileImageUrl = "https://example.com/image2.png"
                        },
                        new Users
                        {
                            Id = 3,
                            FullName = "Test User 3",
                            UserName = "testuser3",
                            Email = "test3@example.com",
                            Password = "password3",
                            ProfileImageUrl = "https://example.com/image3.png"
                        }
                    };

            return Ok(users);
        }
    }
}