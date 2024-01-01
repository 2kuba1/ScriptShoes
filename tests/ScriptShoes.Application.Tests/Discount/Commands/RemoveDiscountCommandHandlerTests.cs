using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Discount.Commands.RemoveDiscount;

namespace ScriptShoes.Application.Tests.Discount.Commands;

public class RemoveDiscountCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenDiscountId_RemovesDiscount()
    {
        //arrange

        var command = new RemoveDiscountCommand(1);

        var discountRepository = new Mock<IDiscountRepository>();

        var discount = new Domain.Entities.Discount()
        {
            Id = 1
        };

        discountRepository.Setup(d => d.GetByIdAsync(1)).ReturnsAsync(discount);
        discountRepository.Setup(d => d.DeleteDiscount(discount));

        var handler = new RemoveDiscountCommandHandler(discountRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Handle_ForNullDiscountObject_ThrowsNotFoundException()
    {
        //arrange

        var command = new RemoveDiscountCommand(1);

        var discountRepository = new Mock<IDiscountRepository>();

        var discount = new Domain.Entities.Discount()
        {
            Id = 1
        };

        discountRepository.Setup(d => d.GetByIdAsync(1)).ReturnsAsync((Domain.Entities.Discount)null);

        var handler = new RemoveDiscountCommandHandler(discountRepository.Object);

        //act

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}