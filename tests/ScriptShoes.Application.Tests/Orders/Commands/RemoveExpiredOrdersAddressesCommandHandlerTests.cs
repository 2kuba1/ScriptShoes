using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;
using ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrdersAddresses;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Orders.Commands;

public class RemoveExpiredOrdersAddressesCommandHandlerTests
{
    [Fact]
    public async Task Handle_RemovesExpiredOrdersAddresses()
    {
        //arrange
        
        var expiredOrders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                SessionExpirationDateTime = new DateTime(2023, 12, 30),
            },
            new Order()
            {
                Id = 2,
                SessionExpirationDateTime = new DateTime(2021, 12, 30),
            }
        };

        var orderAddressRepository = new Mock<IOrderAddressRepository>();
        
        orderAddressRepository.Setup(o => o.RemoveExpiredOrdersAddresses(expiredOrders));

        var handler = new RemoveExpiredOrdersAddressesCommandHandler(orderAddressRepository.Object);
        
        //act

        var result = await handler.Handle(new RemoveExpiredOrdersAddressesCommand(expiredOrders), CancellationToken.None);
        
        //assert

        result.Should().Be(Unit.Value);
    }
}