using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public List<int> ShoeId { get; set; }
}