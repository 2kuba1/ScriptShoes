using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class EmailCode : BaseEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public DateTime Expires { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}