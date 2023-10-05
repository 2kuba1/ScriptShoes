using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Favorite : BaseEntity
{
    public int UserId { get; set; }
    public int ShoeId { get; set; }
}