namespace ScriptShoes.Application.Models.Discount;

public class CreateDiscountDto
{
    public int? DiscountPercentage { get; set; }
    public float? MoneyDiscount { get; set; }
    public List<int> ShoesIds { get; set; }
    public DateTime DiscountStartTime { get; set; }
    public DateTime DiscountEndDateTime { get; set; }
}