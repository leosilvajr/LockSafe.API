using LockSafe.Domain.Models;

namespace LockSafe.Infra.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddAsync(Users user);
    }
}
