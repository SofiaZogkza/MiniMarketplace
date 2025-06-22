using Microsoft.EntityFrameworkCore;
using MiniMarketplace.Application;
using MiniMarketplace.Domain.Models.Dtos;
using MiniMarketplace.Persistence.Data;

namespace MiniMarketplace.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MarketplaceDbContext _context;

    public UserRepository(MarketplaceDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        return await _context.Users
            .Select(user => new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            }).ToListAsync();
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