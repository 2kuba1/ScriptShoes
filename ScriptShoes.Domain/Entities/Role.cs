using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}