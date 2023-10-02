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
            Id = Guid.Parse("212410d0-1181-40f7-8a7c-f9a946bcddd6"),
            Name = "User",
            Created = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        }, new Role()
        {
            Id =  Guid.Parse("50d3b559-99c1-4c51-b94d-01b37d1a1333"),
            Name = "Admin",
            Created = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        });
    }
}