namespace ScriptShoes.Application.Models.Shoe;

public class SearchForShoesDto
{
    public int Id { get; set; }
    public string ShoeName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ShoeType { get; set; } = string.Empty;
    public float CurrentPrice { get; set; }
    public float? PriceBeforeDiscount { get; set; }
    public string? ThumbnailImage { get; set; }
}