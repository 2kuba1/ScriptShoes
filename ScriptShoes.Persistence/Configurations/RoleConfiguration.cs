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
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            Id = 1,
            Name = "User"
        }, new Role()
        {
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            Id = 1,
            Name = "Admin"
        });
    }
}