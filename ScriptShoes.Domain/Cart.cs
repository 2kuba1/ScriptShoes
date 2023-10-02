using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ShoeId { get; set; }
}