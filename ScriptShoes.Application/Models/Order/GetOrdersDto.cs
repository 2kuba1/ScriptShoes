namespace ScriptShoes.Application.Models.Order;

public class GetOrdersDto
{
    public int Id { get; set; }
    public int ShoeId { get; set; }
    public int Quantity { get; set; }

    public int OrderAddressId { get; set; }
    
    public string? ThumbnailImage { get; set; }
    public float CurrentPrice { get; set; }
    public string ShoeName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
}