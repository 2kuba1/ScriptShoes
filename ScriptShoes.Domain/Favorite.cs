using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Favorite : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
}