using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Discount.Commands.CreateDiscount;
using ScriptShoes.Application.Models.Discount;

namespace ScriptShoes.Application.Tests.Discount.Commands;

public class CreateDiscountCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForCorrectData_CreatesDiscount()
    {
        //arrange

        var dto = new CreateDiscountDto()
        {
            DiscountPercentage = 10,
            ShoesIds = new List<int>() { 1 },
            DiscountStartTime = DateTime.Now,
            DiscountEndDateTime = DateTime.Now.AddDays(7)
        };
        
        var command = new CreateDiscountCommand(dto);

        var discountRepository = new Mock<IDiscountRepository>();

        discountRepository.Setup(d => d.CreateDiscount(dto));

        var handler = new CreateDiscountCommandHandler(discountRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);
        
        //assert

        result.Should().Be(Unit.Value);
    }
}