namespace ScriptShoes.Application.Models.Review;

public class AddReviewLikeDto
{
    public int? UserId { get; set; }
    public string? LocalUserId { get; set; }
    public int ReviewId { get; set; }
}