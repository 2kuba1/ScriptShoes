namespace ScriptShoes.Application.Models.Order;

public class CreateCheckoutDto
{
    public Domain.Entities.Shoe Shoe { get; set; }
    public int Quantity { get; set; }
}