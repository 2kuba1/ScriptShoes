using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Role : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}