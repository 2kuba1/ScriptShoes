using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Shoe : BaseEntity
{
    public string ShoeName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ShoeType { get; set; } = string.Empty;
    public List<float>? ShoeSizes { get; set; }
    public float CurrentPrice { get; set; }
    public float? PriceBeforeDiscount { get; set; }
    public float? AverageRating { get; set; }
    public int? NumberOfReviews { get; set; }

    public string? ThumbnailImage { get; set; }
    public List<string>? Images { get; set; }
    
    public Guid UserId { get; set; }
}