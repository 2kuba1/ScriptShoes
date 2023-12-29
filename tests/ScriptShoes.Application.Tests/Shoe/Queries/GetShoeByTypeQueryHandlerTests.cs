using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeByType;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetShoeByTypeQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenShoeType_ReturnsShoe()
    {
        //arrange 

        var getShoeLimitedInformationDtos = new List<GetShoeLimitedInformationDto>()
        {
            new GetShoeLimitedInformationDto()
            {
                Id = 1,
                ShoeName = "Test1",
                ShoeType = "Test",
                AverageRating = 0
            },
            new GetShoeLimitedInformationDto()
            {
                Id = 2,
                ShoeName = "Test2",
                ShoeType = "Test",
                AverageRating = 0
            },
            new GetShoeLimitedInformationDto()
            {
                Id = 3,
                ShoeName = "Test3",
                ShoeType = "Test",
                AverageRating = 0
            }
        };

        var shoe = new List<Domain.Entities.Shoe>()
        {
            new Domain.Entities.Shoe()
            {
                Id = 1,
                ShoeName = "Test1",
                ShoeType = "Test",
                AverageRating = 0
            },
            new Domain.Entities.Shoe()
            {
                Id = 2,
                ShoeName = "Test2",
                ShoeType = "Test",
                AverageRating = 0
            },
            new Domain.Entities.Shoe()
            {
                Id = 3,
                ShoeName = "Test3",
                ShoeType = "Test",
                AverageRating = 0
            },
        };

        var query = new GetShoeByTypeQuery("Test", 3);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetShoeByType(query.ShoeType, query.Count)).ReturnsAsync(shoe);

        var handler = new GetShoeByTypeQueryHandler(shoeRepository.Object);


        //act 

        var result = await handler.Handle(query, CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(getShoeLimitedInformationDtos);
    }
}