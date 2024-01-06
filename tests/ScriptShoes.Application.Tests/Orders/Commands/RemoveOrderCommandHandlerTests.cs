using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Orders.Commands.RemoveOrder;

namespace ScriptShoes.Application.Tests.Orders.Commands;

public class RemoveOrderCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenOrderSessionId_RemovesOrder()
    {
        //arrange

        var command = new RemoveOrderCommand("test");

        var orderRepository = new Mock<IOrderRepository>();

        orderRepository.Setup(o => o.RemoveOrder(command.OrderSessionId));

        var handler = new RemoveOrderCommandHandler(orderRepository.Object);
        
        //act

        var result = await handler.Handle(command, CancellationToken.None);
        
        //assert

        result.Should().Be(Unit.Value);
    }
}