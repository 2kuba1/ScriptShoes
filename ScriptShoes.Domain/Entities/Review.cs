using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Review : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string ReviewDescription { get; set; } = string.Empty;
    public int Likes { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}