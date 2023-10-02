using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class EmailCode : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public DateTime Expires { get; set; }

    public Guid UserId { get; set; }
}