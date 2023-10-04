using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
}