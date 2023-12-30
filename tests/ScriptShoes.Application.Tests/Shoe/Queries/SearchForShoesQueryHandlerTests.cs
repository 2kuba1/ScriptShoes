using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Queries.SearchForShoes;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class SearchForShoesQueryHandlerTests
{
    [Theory]
    [InlineData("Brand")]
    [InlineData("Test")]
    public async Task Handle_ForGivenSearchPhrase_ReturnsPagedSearchForShoesDto(string searchPhrase)
    {
        //arrange

        var query = new SearchForShoesQuery(3, 1, searchPhrase);

        var searchForShoesDtos = new List<SearchForShoesDto>()
        {
            new SearchForShoesDto()
            {
                Id = 1,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test",
                CurrentPrice = 50,
                ThumbnailImage = "#",
            },
            new SearchForShoesDto()
            {
                Id = 2,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test2",
                CurrentPrice = 50,
                ThumbnailImage = "##",
                PriceBeforeDiscount = 10
            },
            new SearchForShoesDto()
            {
                Id = 3,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test3",
                CurrentPrice = 20,
                ThumbnailImage = "##",
            }
        };

        var shoes = new List<Domain.Entities.Shoe>()
        {
            new Domain.Entities.Shoe()
            {
                Id = 1,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test",
                CurrentPrice = 50,
                ThumbnailImage = "#",
                AverageRating = 33,
            },
            new Domain.Entities.Shoe()
            {
                Id = 2,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test2",
                CurrentPrice = 50,
                ThumbnailImage = "##",
                AverageRating = 1,
                PriceBeforeDiscount = 10
            },
            new Domain.Entities.Shoe()
            {
                Id = 3,
                ShoeName = "Test",
                Brand = "Brand",
                ShoeType = "Test3",
                CurrentPrice = 20,
                ThumbnailImage = "##",
                AverageRating = 3,
            }
        };

        var pagedResult = new PagedResult<SearchForShoesDto>(searchForShoesDtos, 3, 3, 1);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetShoesBySearchPhrase(3, 1, searchPhrase)).ReturnsAsync(shoes);

        var handler = new SearchForShoesQueryHandler(shoeRepository.Object);

        //act

        var result = await handler.Handle(query, CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(pagedResult);
    }
}