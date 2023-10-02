using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScriptShoes.Domain;

namespace ScriptShoes.Persistence.Configurations;

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