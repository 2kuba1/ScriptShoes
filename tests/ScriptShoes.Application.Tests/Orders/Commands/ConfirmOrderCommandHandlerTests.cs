using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Orders.Commands;

public class ConfirmOrderCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenSessionId_ConfirmsOrder()
    {
        //arrange

        var paymentService = new Mock<IPaymentsService>();
        var orderRepository = new Mock<IOrderRepository>();
        var shoeRepository = new Mock<IShoeRepository>();

        const string sessionId = "session123";

        var order = new Order()
        {
            Id = 1,
            SessionId = sessionId,
            ShoeId = 1
        };

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1
        };

        paymentService.Setup(p => p.ConfirmOrder(sessionId));
        orderRepository.Setup(o => o.GetOrderBySessionId(sessionId)).ReturnsAsync(order);
        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);

        var handler =
            new ConfirmOrderCommandHandler(paymentService.Object, orderRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(new ConfirmOrderCommand(sessionId), CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }
}