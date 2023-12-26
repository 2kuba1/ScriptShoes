using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Tests.Shoe.Commands;

public class CreateShoeCommandHandlerTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task Handle_ForGivenUserId_CreatesShoe(int userId)
    {
        //arrange 

        var command = new CreateShoeCommand(new CreateShoeDto()
        {
            ShoeName = "Test",
            Quantity = 50,
            CurrentPrice = 99.99f,
        });

        var userRepositoryMock = new Mock<IUserRepository>();

        userRepositoryMock.Setup(c => c.GetUserId).Returns(userId);

        var shoeRepositoryMock = new Mock<IShoeRepository>();

        var handler = new CreateShoeCommandHandler(shoeRepositoryMock.Object, userRepositoryMock.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(0);
    }

    [Fact]
    public async Task Handle_ForNullUserId_ThrowsNotFoundException()
    {
        //arrange 

        var command = new CreateShoeCommand(new CreateShoeDto()
        {
            ShoeName = "Test",
            Quantity = 50,
            CurrentPrice = 99.99f,
        });

        var userRepositoryMock = new Mock<IUserRepository>();

        userRepositoryMock.Setup(c => c.GetUserId).Returns((int?)null);

        var shoeRepositoryMock = new Mock<IShoeRepository>();

        var handler = new CreateShoeCommandHandler(shoeRepositoryMock.Object, userRepositoryMock.Object);

        //act

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}