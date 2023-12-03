using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Entities;

public class OrderAddress : BaseEntity
{
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string OrderSessionId { get; set; }
}