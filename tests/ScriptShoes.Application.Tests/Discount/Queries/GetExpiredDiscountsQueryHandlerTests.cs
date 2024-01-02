using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Discount.Queries.GetExpiredDiscounts;

namespace ScriptShoes.Application.Tests.Discount.Queries;

public class GetExpiredDiscountsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsExpiredDiscounts()
    {
        //arrange

        var discounts = new List<Domain.Entities.Discount>()
        {
            new Domain.Entities.Discount()
            {
                Id = 1,
            },
            new Domain.Entities.Discount()
            {
                Id = 2,
            }
        };

        var discountRepository = new Mock<IDiscountRepository>();

        discountRepository.Setup(d => d.GetExpiredDiscounts()).ReturnsAsync(discounts);

        var handler = new GetExpiredDiscountsQueryHandler(discountRepository.Object);
        
        //act

        var result = await handler.Handle(new GetExpiredDiscountsQuery(), CancellationToken.None);
        
        //assert

        result.Should().BeEquivalentTo(discounts);
    }
}