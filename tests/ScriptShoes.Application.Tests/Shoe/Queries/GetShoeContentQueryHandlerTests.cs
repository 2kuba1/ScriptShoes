using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeContent;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetShoeContentQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenShoeId_ReturnsShoeContent()
    {
        //arrange

        var shoeContent = new GetShoeContentDto()
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

        shoeRepository.Setup(s => s.GetShoeContent(1)).ReturnsAsync(shoe);

        var handler = new GetShoeContentQueryHandler(shoeRepository.Object);

        //act

        var result = await handler.Handle(new GetShoeContentQuery(1), CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(shoeContent);
    }

    [Fact]
    public async Task Handle_ForNullShoeObject_ThrowsNotFoundException()
    {
        //arrange

        var shoeContent = new GetShoeContentDto()
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

        shoeRepository.Setup(s => s.GetShoeContent(1)).ReturnsAsync((Domain.Entities.Shoe)null);

        var handler = new GetShoeContentQueryHandler(shoeRepository.Object);

        //act

        Func<Task> action = async () => await handler.Handle(new GetShoeContentQuery(1), CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}