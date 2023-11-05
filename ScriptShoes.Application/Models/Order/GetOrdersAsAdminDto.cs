namespace ScriptShoes.Application.Models.Order;

public class GetOrdersAsAdminDto
{
    public GetOrdersDto GetOrdersDto { get; set; }
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
}