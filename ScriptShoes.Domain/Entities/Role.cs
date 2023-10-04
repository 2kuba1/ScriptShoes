using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}