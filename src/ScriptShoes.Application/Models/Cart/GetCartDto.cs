namespace ScriptShoes.Application.Models.Cart;

public class GetCartDto
{
    public int ShoeId { get; set; }
    public string ShoeName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public float CurrentPrice { get; set; }
    public string? ThumbnailImage { get; set; }
    public int Quantity { get; set; } = 0;
}