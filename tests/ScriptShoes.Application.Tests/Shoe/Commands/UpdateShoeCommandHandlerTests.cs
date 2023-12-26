using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Commands;

public class UpdateShoeCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForValidData_UpdatesShoe()
    {
        //arrange

        var dto = new UpdateShoeDto()
        {
            NewName = "Test1",
            Quantity = 5,
            CurrentPrice = 50.10f,
            Images = new List<string>()
            {
                "#",
            },
            Brand = "Test 12345",
            ShoeType = "Test1",
            SizesList = new List<float>() { 23, 4 },
            ThumbnailImage = "##"
        };

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1,
            ShoeName = "Test",
            Quantity = 10,
            CurrentPrice = 10.10f,
            Images = new List<string>()
            {
                "#",
                "##"
            },
            Brand = "Test 123",
            ShoeType = "Test",
            ShoeSizes = new List<float>() { 1, 23, 4, 56, },
            ThumbnailImage = "#"
        };

        var command = new UpdateShoeCommand(1, dto);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);
        shoeRepository.Setup(s => s.UpdateAsync(shoe));

        var handler = new UpdateShoeCommandHandler(shoeRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Handle_ForNullShoeObject_ThrowsNotFoundException()
    {
        //arrange

        var dto = new UpdateShoeDto()
        {
            NewName = "Test1",
            Quantity = 5,
            CurrentPrice = 50.10f,
            Images = new List<string>()
            {
                "#",
            },
            Brand = "Test 12345",
            ShoeType = "Test1",
            SizesList = new List<float>() { 23, 4 },
            ThumbnailImage = "##"
        };


        var command = new UpdateShoeCommand(1, dto);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((Domain.Entities.Shoe?)null);

        var handler = new UpdateShoeCommandHandler(shoeRepository.Object);

        //act

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}