namespace ScriptShoes.Domain.Entities;

public class ReviewLike
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ReviewId { get; set; }
}