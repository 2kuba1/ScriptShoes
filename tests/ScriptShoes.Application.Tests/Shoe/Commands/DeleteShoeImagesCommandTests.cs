using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoeImages;

namespace ScriptShoes.Application.Tests.Shoe.Commands;

public class DeleteShoeImagesCommandTests
{
    public static IEnumerable<object[]> GetSampleData()
    {
        yield return new object[]
        {
            new List<string>() { "#", "###", "##", "####" },
            new DeleteShoeImagesCommand(1, new List<int>()
            {
                0, 2
            })
        };
        yield return new object[]
        {
            new List<string>() { "#", "####" },
            new DeleteShoeImagesCommand(2, new List<int>()
            {
                0, 1
            }),
        };
        yield return new object[]
        {
            new List<string>() { "#", "###", "##", "####", "#####" },
            new DeleteShoeImagesCommand(3, new List<int>()
            {
                2, 1
            }),
        };
        yield return new object[]
        {
            new List<string>() { "#", "###", "##", "####" },
            new DeleteShoeImagesCommand(4, new List<int>()
            {
                0, 3
            })
        };
    }

    [Theory]
    [MemberData(nameof(GetSampleData))]
    public async Task Handle_ForValidData_DeletesShoeImage(List<string> images,
        DeleteShoeImagesCommand command)
    {
        //arrange

        var shoe = new Domain.Entities.Shoe()
        {
            Id = command.Id,
            Images = images
        };

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(command.Id)).ReturnsAsync(shoe);
        shoeRepository.Setup(s => s.UpdateAsync(shoe));

        var handler = new DeleteShoeImagesCommandHandler(shoeRepository.Object);

        //act 

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Theory]
    [MemberData(nameof(GetSampleData))]
    public async Task Handler_ForNullShoeObject_ThrowsNotFoundException(List<string> images,
        DeleteShoeImagesCommand command)
    {
        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(command.Id)).ReturnsAsync((Domain.Entities.Shoe?)null);

        var handler = new DeleteShoeImagesCommandHandler(shoeRepository.Object);

        //act 

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}