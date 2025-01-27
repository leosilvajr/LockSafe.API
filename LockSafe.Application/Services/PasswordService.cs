using LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using LockSafe.Domain.Models;
using LockSafe.Infra.Repositories.Interface;

namespace LockSafe.Application.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordAllowanceRepository _passwordAllowanceRepository;

        public PasswordService(IPasswordRepository passwordRepository, IPasswordAllowanceRepository passwordAllowanceRepository)
        {
            _passwordRepository = passwordRepository;
            _passwordAllowanceRepository = passwordAllowanceRepository;
        }

        public async Task<PasswordDTO> CreatePasswordAsync(PasswordCreateDTO passwordDto, int userId)
        {
            // Mapear DTO para entidade Password
            var password = new Password
            {
                Title = passwordDto.Title,
                Description = passwordDto.Description,
                Reference = passwordDto.Reference,
                Account = passwordDto.Account,
                PasswordValue = passwordDto.PasswordValue,
                CreationDate = DateTime.Now,
                ExpirationDate = passwordDto.ExpirationDate
            };

            // Salvar a senha no banco de dados
            var createdPassword = await _passwordRepository.AddAsync(password);

            // Criar o registro em PasswordAllowance
            var passwordAllowance = new PasswordAllowance
            {
                PasswordId = createdPassword.Id,
                UserId = userId,
                IsAdmin = passwordDto.IsAdmin
            };

            await _passwordAllowanceRepository.AddAsync(passwordAllowance);

            // Retornar os dados criados
            return new PasswordDTO
            {
                Id = createdPassword.Id,
                Title = createdPassword.Title,
                Description = createdPassword.Description,
                Reference = createdPassword.Reference,
                Account = createdPassword.Account,
                PasswordValue = createdPassword.PasswordValue,
                CreationDate = createdPassword.CreationDate,
                ExpirationDate = createdPassword.ExpirationDate
            };
        }
    }
}
