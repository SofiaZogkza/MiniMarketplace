namespace MiniMarketplace.Application
{
    public interface IUserRepository
    {
        Task<(bool EmailExists, bool UsernameExists)> CheckEmailAndUsernameExistAsync(string email, string username);
    }
}