namespace ScriptShoes.Application.Models.Order;

public class OrderDto
{
    public List<PaymentRequestDto> Items { get; set; }
    public OrderAddressDto Address { get; set; }
}