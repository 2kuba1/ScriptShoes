using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
    public int ItemCount { get; set; }
}