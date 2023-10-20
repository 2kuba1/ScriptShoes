namespace ScriptShoes.Application.Models.Review;

public class GetShoeReviewsDto
{
    public string Title { get; set; } = string.Empty;
    public string ReviewDescription { get; set; } = string.Empty;
    public int Likes { get; set; }
    public float ShoeRate { get; set; }

    public string Username { get; set; }
    public DateTime Created { get; set; }
}