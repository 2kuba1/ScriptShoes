using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Discount.Commands.RemoveExpiredDiscounts;

namespace ScriptShoes.Application.Tests.Discount.Commands;

public class RemoveExpiredDiscountsCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenDiscounts_RemovesExpiredDiscounts()
    {
        //arrange

        var discounts = new List<Domain.Entities.Discount>()
        {
            new Domain.Entities.Discount()
            {
                Id = 1,
                DiscountEndDateTime = new DateTime(2023, 12, 30)
            },
            new Domain.Entities.Discount()
            {
                Id = 2,
                DiscountEndDateTime = new DateTime(2024, 12, 30)
            },
        };

        var discountRepository = new Mock<IDiscountRepository>();

        discountRepository.Setup(d => d.RemoveExpiredDiscounts(discounts));

        var handler = new RemoveExpiredDiscountsCommandHandler(discountRepository.Object);

        //act

        var result = await handler.Handle(new RemoveExpiredDiscountsCommand(discounts), CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }
}