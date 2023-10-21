using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class ReviewLike : BaseEntity
{
    public int? UserId { get; set; }
    public string? LocalId { get; set; }
    public int ReviewId { get; set; }
    public int ShoeId { get; set; }
}