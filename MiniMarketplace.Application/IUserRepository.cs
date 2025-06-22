using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application
{
    public interface IUserRepository
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<(bool EmailExists, bool UsernameExists)> CheckEmailAndUsernameExistAsync(string email, string username);
    }
}