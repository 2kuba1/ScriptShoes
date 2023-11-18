namespace ScriptShoes.Application.Models.Review;

public class GetShoeRatesDto
{
    public int ShoeId { get; set; }
    public int OneStarsCount { get; set; }
    public int TwoStarsCount { get; set; }
    public int ThreeStarsCount { get; set; }
    public int FourStarsCount { get; set; }
    public int FiveStarsCount { get; set; }
}