namespace ScriptShoes.Application.Models.Payments;

public class CreateCheckoutDto
{
    public Domain.Entities.Shoe Shoe { get; set; }
    public int Quantity { get; set; }
}