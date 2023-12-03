namespace ScriptShoes.Application.Models.Order;

public class UserOrdersDto
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int ShoeId { get; set; }
    public string ShoeName { get; set; } = string.Empty;
    public string? ThumbnailImage { get; set; }
    public string Brand { get; set; } = string.Empty;
}