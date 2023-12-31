using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Cart.Commands.RemoveFromCart;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Cart.Commands;

public class RemoveFromCartCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForCorrectData_RemovesShoeFromCart()
    {
        //arrange

        var command = new RemoveFromCartCommand(1, 2);

        var shoeRepository = new Mock<IShoeRepository>();
        var userRepository = new Mock<IUserRepository>();
        var cartRepository = new Mock<ICartRepository>();

        var shoe = new Domain.Entities.Shoe()
        {
            Id = 1,
            Quantity = 10,
        };

        var user = new User()
        {
            Id = 1,
            Username = "Test",
        };

        var cart = new Domain.Entities.Cart()
        {
            Id = 1,
            ItemCount = 5,
            ShoeId = 1,
            UserId = 1,
        };

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);
        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync(user);
        cartRepository.Setup(c => c.GetByUserIdAndItemId(1, 1)).ReturnsAsync(cart);
        cartRepository.Setup(c => c.DeleteAsync(cart));
        cartRepository.Setup(c => c.UpdateAsync(cart));

        var handler =
            new RemoveFromCartCommandHandler(cartRepository.Object, userRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        cart.ItemCount.Should().Be(3);
        result.Should().Be(Unit.Value);
    }
}