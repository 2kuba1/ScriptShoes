using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Entities;

public class Favorite : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
}