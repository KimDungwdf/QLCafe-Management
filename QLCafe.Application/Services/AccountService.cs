using System.Collections.Generic;
using System.Linq;
using QLCafe.Application.DTOs.Account;
using QLCafe.Domain.Entities;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Application.Services
{
    public class AccountService
    {
        private readonly AccountRepository _repo;
        public AccountService(string connectionString)
        {
            _repo = new AccountRepository(connectionString);
        }

        public List<AccountDto> GetAll()
        {
            var entities = _repo.GetAccounts();
            return entities.Select(MapToDto).ToList();
        }

        public AccountDto Create(AccountDto dto, string password)
        {
            var entity = new Account
            {
                Username = dto.Username,
                DisplayName = dto.DisplayName,
                Phone = dto.Phone,
                Status = dto.Status ?? "Hoạt động",
                Role = dto.Role,
                Password = password
            };
            _repo.Create(entity);
            return MapToDto(entity);
        }

        public bool Update(AccountDto dto)
        {
            var entity = new Account
            {
                Username = dto.Username,
                DisplayName = dto.DisplayName,
                Role = dto.Role
            };
            return _repo.Update(entity);
        }

        public bool Delete(string username)
        {
            return _repo.Delete(username);
        }

        public bool UsernameExists(string username)
        {
            return _repo.UsernameExists(username);
        }

        public AccountDto GetByUsername(string username)
        {
            var account = _repo.GetByUsername(username);
            return account != null ? MapToDto(account) : null;
        }

        private AccountDto MapToDto(Account a)
        {
            return new AccountDto
            {
                Username = a.Username,
                DisplayName = a.DisplayName,
                Phone = a.Phone,
                Status = a.Status,
                Role = a.Role
            };
        }
    }
}
