namespace ScriptShoes.Application.Models.Review;

public class CreateReviewDto
{
    public int ShoeId { get; set; }
    public string Title { get; set; }
    public string ReviewDescription { get; set; }
    public int ShoeRate { get; set; }
}