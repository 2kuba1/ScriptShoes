using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Cart : BaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ShoeId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Shoe Shoe { get; set; }
}