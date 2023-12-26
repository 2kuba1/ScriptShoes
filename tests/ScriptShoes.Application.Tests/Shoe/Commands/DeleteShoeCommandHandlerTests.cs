using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoe;

namespace ScriptShoes.Application.Tests.Shoe.Commands;

public class DeleteShoeCommandHandlerTests
{
    [Fact]
    public async Task Handler_ForGivenShoeId_DeletesShoe()
    {
        //arrange

        var command = new DeleteShoeCommand(1);

        var shoe = new Domain.Entities.Shoe()
        {
            ShoeName = "Test",
        };

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);
        shoeRepository.Setup(s => s.DeleteAsync(shoe));

        var handler = new DeleteShoeCommandHandler(shoeRepository.Object);

        //act 

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Handler_ForNullShoeObject_ThrowsNotFoundException()
    {
        //arrange

        var command = new DeleteShoeCommand(1);

        var shoeRepository = new Mock<IShoeRepository>();

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((Domain.Entities.Shoe?)null);

        var handler = new DeleteShoeCommandHandler(shoeRepository.Object);

        //act 

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await Assert.ThrowsAsync<NotFoundException>(action);
    }
}