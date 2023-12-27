using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Queries.GetPagedShoes;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetPagedShoesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForValidData_ReturnsPagedShoes()
    {
        var getShoeLimitedInformationDtos = new List<GetShoeLimitedInformationDto>()
        {
            new GetShoeLimitedInformationDto()
            {
                Id = 1,
                ShoeName = "Test1",
                Brand = "Test",
                ShoeType = "Test",
                CurrentPrice = 50,
                ThumbnailImage = "#",
                AverageRating = 33,
            },
            new GetShoeLimitedInformationDto()
            {
                Id = 2,
                ShoeName = "Test2",
                Brand = "Test2",
                ShoeType = "Test2",
                CurrentPrice = 50,
                ThumbnailImage = "##",
                AverageRating = 1,
                PriceBeforeDiscount = 10
            },
            new GetShoeLimitedInformationDto()
            {
                Id = 3,
                ShoeName = "Test3",
                Brand = "Test3",
                ShoeType = "Test3",
                CurrentPrice = 20,
                ThumbnailImage = "##",
                AverageRating = 3,
            }
        };

        //arrange

        var query = new GetPagedShoesQuery(1, 2);

        var shoes = new List<Domain.Entities.Shoe>()
        {
            new Domain.Entities.Shoe()
            {
                Id = 1,
                ShoeName = "Test1",
                Brand = "Test",
                ShoeType = "Test",
                CurrentPrice = 50,
                ThumbnailImage = "#",
                AverageRating = 33,
            },
            new Domain.Entities.Shoe()
            {
                Id = 2,
                ShoeName = "Test2",
                Brand = "Test2",
                ShoeType = "Test2",
                CurrentPrice = 50,
                ThumbnailImage = "##",
                AverageRating = 1,
                PriceBeforeDiscount = 10
            },
            new Domain.Entities.Shoe()
            {
                Id = 3,
                ShoeName = "Test3",
                Brand = "Test3",
                ShoeType = "Test3",
                CurrentPrice = 20,
                ThumbnailImage = "##",
                AverageRating = 3,
            }
        };


        var dto = new PagedResult<GetShoeLimitedInformationDto>(getShoeLimitedInformationDtos, 3, 2, 1);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetPagedShoes(1, 2)).ReturnsAsync(shoes);

        var handler = new GetPagedShoesQueryHandler(shoeRepository.Object);

        //act 

        var result = await handler.Handle(query, CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(dto);
    }
}