using ScriptShoes.Domain.Common;
using ScriptShoes.Domain.ValueObjects;
using ScriptShoes.Domain.ValueObjects.User;

namespace ScriptShoes.Domain.Entities;

public sealed class User : BaseEntity
{
    public Username Username { get; init; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }
    public float AvailableFounds { get; set; } = 0;
    public string FirsName { get; set; }
    public string LastName { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationTime { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}