using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class EmailCode : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public DateTime Expires { get; set; }

    public int UserId { get; set; }
}