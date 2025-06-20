using Microsoft.EntityFrameworkCore;
using MiniMarketplace.Persistence.Entities;

namespace MiniMarketplace.Persistence.Data;

public class MarketplaceDbContext : DbContext
{
    public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options)
    {
        
    }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(MarketplaceDbContext).Assembly);
    }
}