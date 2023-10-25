using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Review : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string ReviewDescription { get; set; } = string.Empty;
    public int Likes { get; set; }
    public float ShoeRate { get; set; }
    public string Username { get; set; }
    
    public int ShoeId { get; set; }
    public int UserId { get; set; }
    
    public virtual Shoe Shoe { get; set; }
    public virtual User User { get; set; }
}