using Microsoft.EntityFrameworkCore;
using MiniMarketplace.Application;
using MiniMarketplace.Persistence.Data;

namespace MiniMarketplace.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MarketplaceDbContext _context;

    public UserRepository(MarketplaceDbContext context)
    {
        _context = context;
    }

    public async Task<(bool EmailExists, bool UsernameExists)> CheckEmailAndUsernameExistAsync(string email, string username)
    {
        var users = await _context.Users
            .Where(u => u.Email == email || u.Username == username)
            .Select(u => new { u.Email, u.Username })
            .ToListAsync();

        bool emailExists = users.Any(u => u.Email == email);
        bool usernameExists = users.Any(u => u.Username == username);

        return (emailExists, usernameExists);
    }

    // Add other methods to create, get user, etc.
}