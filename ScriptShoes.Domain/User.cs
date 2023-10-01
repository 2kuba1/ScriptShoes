using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class User : BaseEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public float AvailableFounds { get; set; }
    public string FirsName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }

    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}