using MiniMarketplace.Domain.Models;
using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateUserAsync(User user);
        Task<(bool EmailExists, bool UsernameExists)> CheckEmailAndUsernameExistAsync(string email, string username);
    }
}