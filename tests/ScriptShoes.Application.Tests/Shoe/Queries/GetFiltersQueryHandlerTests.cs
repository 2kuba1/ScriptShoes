using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Queries.GetFilters;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Queries;

public class GetFiltersQueryHandlerTests
{
    private readonly List<Domain.Entities.Shoe> _shoes;

    public GetFiltersQueryHandlerTests()
    {
        _shoes = new List<Domain.Entities.Shoe>()
        {
            new Domain.Entities.Shoe()
            {
                Id = 1,
                Brand = "Test1",
                ShoeType = "Test1",
                ShoeSizes = new List<float>() { 1, 2 },
            },
            new Domain.Entities.Shoe()
            {
                Id = 2,
                Brand = "Test2",
                ShoeType = "Test2",
                ShoeSizes = new List<float>() { 1, 2, 3 },
            },
            new Domain.Entities.Shoe()
            {
                Id = 3,
                Brand = "Test3",
                ShoeType = "Test3",
                ShoeSizes = new List<float>() { 11, 23, 2, 3 },
            }
        };
    }

    [Fact]
    public async Task Handle_ForValidData_ReturnsFilters()
    {
        //arrange

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetAsync()).ReturnsAsync(_shoes);

        var filters = new GetFiltersDto()
        {
            Brand = new List<string>()
            {
                "Test1",
                "Test2",
                "Test3",
            },
            ShoeType = new List<string>()
            {
                "Test1",
                "Test2",
                "Test3",
            },
            Sizes = new List<float>()
            {
                1, 2, 3, 11, 23
            }
        };

        var handler = new GetFiltersQueryHandler(shoeRepository.Object);

        //act

        var result = await handler.Handle(new GetFiltersQuery(), CancellationToken.None);

        //assert 

        result.Should().BeEquivalentTo(filters);
    }

    [Fact]
    public async Task Handle_ForNullShoeObject_ThrowsNotFoundException()
    {
        //arrange

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetAsync()).ReturnsAsync((List<Domain.Entities.Shoe>?)null);

        var handler = new GetFiltersQueryHandler(shoeRepository.Object);

        //act

        Func<Task> action = async () => await handler.Handle(new GetFiltersQuery(), CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}