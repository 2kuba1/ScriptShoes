using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Orders.Commands;

public class RemoveExpiredOrdersCommandHandlerTests
{
    [Fact]
    public async Task Handle_RemovesExpiredOrders()
    {
        //arrange

        var orderRepository = new Mock<IOrderRepository>();

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

        orderRepository.Setup(o => o.RemoveExpiredOrders(expiredOrders));

        var handler = new RemoveExpiredOrdersCommandHandler(orderRepository.Object);
        
        //act

        var result = await handler.Handle(new RemoveExpiredOrdersCommand(expiredOrders), CancellationToken.None);
        
        //assert

        result.Should().Be(Unit.Value);
    }
}