using ScriptShoes.Domain.Common;
using ScriptShoes.Domain.ValueObjects.User;

namespace ScriptShoes.Domain.Entities;

public sealed class User : BaseEntity
{
    public Username Username { get; init; }
    public HashedPassword HashedPassword { get; private set; }
    public Email Email { get; init; }
    public AvailableFounds AvailableFounds { get; private set; } = 0;
    public FirstName FirstName { get; init; }
    public LastName LastName { get; init; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationTime { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public void SetHashedPassword(HashedPassword hashedPassword)
    {
        HashedPassword = hashedPassword;
    }

    public void SetAvailableFounds(AvailableFounds availableFounds)
    {
        AvailableFounds = availableFounds;
    }
}