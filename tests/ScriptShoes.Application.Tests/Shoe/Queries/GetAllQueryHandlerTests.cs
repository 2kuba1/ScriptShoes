using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetAllQueryHandlerTests
{
    [Fact]
    public async Task Handler_ReturnsAllShoes()
    {
        //arrange

        var shoes = new List<Domain.Entities.Shoe>()
        {
            new Domain.Entities.Shoe()
            {
                Id = 1,
                ShoeName = "Test1",
                Brand = "Test",
                ShoeType = "Test",
                Quantity = 50,
                CurrentPrice = 50,
                ThumbnailImage = "#",
                ShoeSizes = new List<float>() { 1, 2, 3 },
                Images = new List<string>() { "#", "##" },
                UserId = 1,
                AverageRating = 33,
                NumberOfReviews = 52
            },
            new Domain.Entities.Shoe()
            {
                Id = 2,
                ShoeName = "Test2",
                Brand = "Test2",
                ShoeType = "Test2",
                Quantity = 50,
                CurrentPrice = 50,
                ThumbnailImage = "##",
                ShoeSizes = new List<float>() { 1, 2, 3 },
                Images = new List<string>() { "#", "##" },
                UserId = 1,
                AverageRating = 1,
                NumberOfReviews = 2,
                PriceBeforeDiscount = 10
            },
            new Domain.Entities.Shoe()
            {
                Id = 3,
                ShoeName = "Test3",
                Brand = "Test3",
                ShoeType = "Test3",
                Quantity = 1,
                CurrentPrice = 20,
                ThumbnailImage = "##",
                ShoeSizes = new List<float>() { 11, 23, 2, 3 },
                Images = new List<string>() { "#", "##", "###" },
                UserId = 1,
                AverageRating = 3,
                NumberOfReviews = 5
            }
        };

        var dto = new List<GetShoeDto>()
        {
            new GetShoeDto()
            {
                Id = 1,
                ShoeName = "Test1",
                Brand = "Test",
                ShoeType = "Test",
                CurrentPrice = 50,
                ThumbnailImage = "#",
                ShoeSizes = new List<float>() { 1, 2, 3 },
                Images = new List<string>() { "#", "##" },
                AverageRating = 33,
                NumberOfReviews = 52,
            },
            new GetShoeDto()
            {
                Id = 2,
                ShoeName = "Test2",
                Brand = "Test2",
                ShoeType = "Test2",
                CurrentPrice = 50,
                ThumbnailImage = "##",
                ShoeSizes = new List<float>() { 1, 2, 3 },
                Images = new List<string>() { "#", "##" },
                AverageRating = 1,
                NumberOfReviews = 2,
                PriceBeforeDiscount = 10
            },
            new GetShoeDto()
            {
                Id = 3,
                ShoeName = "Test3",
                Brand = "Test3",
                ShoeType = "Test3",
                CurrentPrice = 20,
                ThumbnailImage = "##",
                ShoeSizes = new List<float>() { 11, 23, 2, 3 },
                Images = new List<string>() { "#", "##", "###" },
                AverageRating = 3,
                NumberOfReviews = 5
            }
        };

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetAsync()).ReturnsAsync(shoes);

        var handler = new GetAllShoesQueryHandler(shoeRepository.Object);

        //act

        var result = await handler.Handle(new GetAllShoesQuery(), CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(dto);
    }
}