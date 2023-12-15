using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.ValueObjects.User;

namespace ScriptShoes.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
            .HasConversion(x => x.Value, x => new Username(x));

        builder.Property(x => x.HashedPassword)
            .HasConversion(x => x.Value, x => new HashedPassword(x));

        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x));

        builder.Property(x => x.AvailableFounds)
            .HasConversion(x => x.Value, x => new AvailableFounds(x));

        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x));

        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x));
    }
}