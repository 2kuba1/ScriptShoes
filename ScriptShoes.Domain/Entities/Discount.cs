using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Discount : BaseEntity
{
    public int ShoeId { get; set; }
    public float PriceBeforeDiscount { get; set; }
    public float CurrentPrice { get; set; }
    public DateTime DiscountEndDateTime { get; set; }
}