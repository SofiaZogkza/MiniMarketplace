using MiniMarketplace.Domain.Models;

namespace MiniMarketplace.Application
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<(bool EmailExists, bool UsernameExists)> CheckEmailAndUsernameExistAsync(string email, string username);
    }
}