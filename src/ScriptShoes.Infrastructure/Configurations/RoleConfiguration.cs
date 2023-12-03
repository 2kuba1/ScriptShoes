using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role()
        {
            Id = 1,
            Name = "User",
            Created = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        }, new Role()
        {
            Id =  2,
            Name = "Admin",
            Created = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        });
    }
}