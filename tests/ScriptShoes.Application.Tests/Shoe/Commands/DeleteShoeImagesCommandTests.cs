using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoeImages;

namespace ScriptShoes.Application.Tests.Shoe.Commands;

public class DeleteShoeImagesCommandTests
{
    [Fact]
    public async Task Handle_ForValidData_DeletesShoeImage()
    {
        //arrange

        var command = new DeleteShoeImagesCommand(1, new List<int>()
        {
            0, 2
        });

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1,
            Images = new List<string>()
            {
                "#",
                "##",
                "###"
            }
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

    [Fact]
    public async Task Handler_ForNullShoeObject_ThrowsNotFoundException()
    {
        //arrange

        var command = new DeleteShoeImagesCommand(1, new List<int>()
        {
            0, 2
        });


        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(command.Id)).ReturnsAsync((Domain.Entities.Shoe?)null);

        var handler = new DeleteShoeImagesCommandHandler(shoeRepository.Object);

        //act 

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}