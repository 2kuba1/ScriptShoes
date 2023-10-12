using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public float AvailableFounds { get; set; }
    public string FirsName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }

    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

    public DateTime AccessTokenExpirationTime { get; set; }
    public DateTime RefreshTokenExpirationTime { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}