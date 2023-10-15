using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
    public int ItemsCount { get; set; }
    public float AmountOfMoney { get; set; }

    public virtual Shoe Shoe { get; set; }
}