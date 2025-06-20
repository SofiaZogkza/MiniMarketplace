using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMarketplace.Persistence.Entities;

namespace MiniMarketplace.Persistence.Data.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasIndex(u => u.Email).IsUnique();
    }
}