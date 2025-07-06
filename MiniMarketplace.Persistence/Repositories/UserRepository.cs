using Microsoft.EntityFrameworkCore;
using MiniMarketplace.Application;
using MiniMarketplace.Domain.Models;
using MiniMarketplace.Domain.Models.Dtos;
using MiniMarketplace.Persistence.Data;
using MiniMarketplace.Persistence.Entities;
using MiniMarketplace.Persistence.Mappers;

namespace MiniMarketplace.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MarketplaceDbContext _context;

    public UserRepository(MarketplaceDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var entities = await _context.Users.ToListAsync();
        var userDomainModel = UserEntityMapper.ToDomain;
        var result = entities.Select(userDomainModel).ToList();
        return result;
    }


    public async Task<User> CreateUserAsync(User user)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var entity = UserEntityMapper.ToEntity(user);
            var newUser = await _context.Users.AddAsync(entity);
        
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        
            return UserEntityMapper.ToDomain(newUser.Entity);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
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
}