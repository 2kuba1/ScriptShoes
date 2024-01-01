using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Discount.Commands.RemoveShoeFromDiscount;

namespace ScriptShoes.Application.Tests.Discount.Commands;

public class RemoveShoeFromDiscountCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenShoeId_RemovesShoeFromDiscount()
    {
        //arrange

        var discount = new Domain.Entities.Discount()
        {
            Id = 1,
            DiscountEndDateTime = new DateTime(2023, 12, 30),
            ShoesIds = new List<int>() { 1 }
        };

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1
        };

        var discountRepository = new Mock<IDiscountRepository>();
        var shoeRepository = new Mock<IShoeRepository>();

        discountRepository.Setup(d => d.GetDiscountByShoeId(1)).ReturnsAsync(discount);
        discountRepository.Setup(d => d.RemoveShoeFromDiscount(discount, shoe));
        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);

        var handler = new RemoveShoeFromDiscountCommandHandler(discountRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(new RemoveShoeFromDiscountCommand(1), CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }
}