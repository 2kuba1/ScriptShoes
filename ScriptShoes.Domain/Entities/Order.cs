using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Order : BaseEntity
{
    public int ShoeId { get; set; }
    public int Quantity { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public string SessionId { get; set; } = string.Empty;
    public DateTime SessionExpirationDateTime { get; set; }
    public int? UserId { get; set; }
}