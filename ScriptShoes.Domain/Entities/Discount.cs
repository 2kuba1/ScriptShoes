using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Discount : BaseEntity
{
    public int? DiscountPercentage { get; set; }
    public float? MoneyDiscount { get; set; }
    public List<int> ShoesIds { get; set; }
    public DateTime DiscountStartTime { get; set; }
    public DateTime DiscountEndDateTime { get; set; }
}