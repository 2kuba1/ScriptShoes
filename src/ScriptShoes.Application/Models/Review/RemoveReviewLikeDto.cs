namespace ScriptShoes.Application.Models.Review;

public class RemoveReviewLikeDto
{
    public int? UserId { get; set; }
    public string? LocalUserId { get; set; }
    public int ReviewId { get; set; }
}