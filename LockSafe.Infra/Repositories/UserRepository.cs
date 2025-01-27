using LockSafe.Domain.Models;
using LockSafe.Infra.Context;
using LockSafe.Infra.Repositories.Interface;

namespace LockSafe.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LockSafeContext _context;

        public UserRepository(LockSafeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Users user)
        {
            await _context.Users.AddAsync(user); // Adiciona o usuário no banco
            await _context.SaveChangesAsync();  // Salva as mudanças
        }
    }
}
