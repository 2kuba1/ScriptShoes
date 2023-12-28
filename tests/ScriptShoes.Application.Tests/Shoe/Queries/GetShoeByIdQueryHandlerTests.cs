using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeById;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetShoeByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenId_ReturnsGetShoeDto()
    {
        //arrange 

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1,
            ShoeName = "Test1",
            Brand = "Test",
            ShoeType = "Test",
            CurrentPrice = 50,
            ThumbnailImage = "#",
            AverageRating = 33,
            Quantity = 10,
            NumberOfReviews = 0
        };

        var dto = new GetShoeDto()
        {
            Id = 1,
            ShoeName = "Test1",
            Brand = "Test",
            ShoeType = "Test",
            CurrentPrice = 50,
            ThumbnailImage = "#",
            AverageRating = 33,
            NumberOfReviews = 0
        };

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);

        var handler = new GetShoeByIdQueryHandler(shoeRepository.Object);

        //act 

        var result = await handler.Handle(new GetShoeByIdQuery(1), CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(dto);
    }

    [Fact]
    public async Task Handle_ForNullShoeObject_ReturnsGetShoeDto()
    {
        //arrange 

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1,
            ShoeName = "Test1",
            Brand = "Test",
            ShoeType = "Test",
            CurrentPrice = 50,
            ThumbnailImage = "#",
            AverageRating = 33,
            Quantity = 10,
            NumberOfReviews = 0
        };

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((Domain.Entities.Shoe)null);

        var handler = new GetShoeByIdQueryHandler(shoeRepository.Object);

        //act 

        Func<Task> action = async () => await handler.Handle(new GetShoeByIdQuery(1), CancellationToken.None);

        //assert 

        await action.Should().ThrowAsync<NotFoundException>();
    }
}