using FluentAssertions;
using MediatR;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Features.Cart.Commands.AddToCart;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Cart.Commands;

public class AddToCartCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForEmptyCart_UpdatesCart()
    {
        //arrange

        var command = new AddToCartCommand(1, 2);

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
            ItemCount = 2,
            ShoeId = 1,
            UserId = 1,
        };

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);
        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync(user);
        cartRepository.Setup(c => c.GetByUserIdAndItemId(1, 1)).ReturnsAsync((Domain.Entities.Cart)null);
        cartRepository.Setup(c => c.CreateAsync(cart));

        var handler = new AddToCartCommandHandler(cartRepository.Object, userRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Handle_ForNotEmptyCart_UpdatesCart()
    {
        //arrange

        var command = new AddToCartCommand(1, 2);

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
            ItemCount = 2,
            ShoeId = 1,
            UserId = 1,
        };

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe);
        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync(user);
        cartRepository.Setup(c => c.GetByUserIdAndItemId(1, 1)).ReturnsAsync(cart);
        cartRepository.Setup(c => c.UpdateAsync(cart));

        var handler = new AddToCartCommandHandler(cartRepository.Object, userRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(command, CancellationToken.None);

        //assert

        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Handle_ForNullShoeObject_ThrowsNotFoundException()
    {
        var command = new AddToCartCommand(1, 2);

        var shoeRepository = new Mock<IShoeRepository>();
        var userRepository = new Mock<IUserRepository>();
        var cartRepository = new Mock<ICartRepository>();

        var handler = new AddToCartCommandHandler(cartRepository.Object, userRepository.Object, shoeRepository.Object);

        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((Domain.Entities.Shoe)null);

        //act

        Func<Task> action = async () => await handler.Handle(command, CancellationToken.None);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}