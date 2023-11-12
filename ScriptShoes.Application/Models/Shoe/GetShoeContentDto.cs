using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Models.Shoe;

public class GetShoeContentDto
{
    public int Id { get; set; }
    public string ShoeName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public List<float>? ShoeSizes { get; set; }
    public float CurrentPrice { get; set; }
    public float? PriceBeforeDiscount { get; set; }
    public float? AverageRating { get; set; }
    public int? NumberOfReviews { get; set; }
    public int Quantity { get; set; }
    public string? ThumbnailImage { get; set; }
    public List<string>? Images { get; set; }
}