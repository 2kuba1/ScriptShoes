using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Review : BaseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ReviewDescription { get; set; } = string.Empty;
    public int Likes { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}