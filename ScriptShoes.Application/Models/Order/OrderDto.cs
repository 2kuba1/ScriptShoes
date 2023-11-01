namespace ScriptShoes.Application.Models.Order;

public class OrderDto
{
    public List<PaymentRequestDto> PaymentRequestDtos { get; set; }
    public OrderAddressDto AddressDto { get; set; }
}