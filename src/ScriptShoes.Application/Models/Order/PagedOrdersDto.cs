namespace ScriptShoes.Application.Models.Order;

public class PagedOrdersDto
{
    public GetOrdersDto GetOrdersDto { get; set; }
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
}