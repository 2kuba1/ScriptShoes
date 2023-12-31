using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Cart.Queries.GetItemsFromCart;
using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Cart.Queries;

public class GetItemsFromCartQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidUser_ReturnsItemsFromCart()
    {
        //arrange

        var cartRepository = new Mock<ICartRepository>();
        var userRepository = new Mock<IUserRepository>();
        var shoeRepository = new Mock<IShoeRepository>();

        var userCarts = new List<Domain.Entities.Cart>()
        {
            new Domain.Entities.Cart()
            {
                Id = 1,
                ItemCount = 1,
                ShoeId = 1,
                UserId = 1
            },
            new Domain.Entities.Cart()
            {
                Id = 2,
                ItemCount = 3,
                ShoeId = 2,
                UserId = 1
            },
        };

        var shoe1 = new Domain.Entities.Shoe()
        {
            Id = 1,
            Brand = "Test",
            CurrentPrice = 10,
            Quantity = 10,
            ThumbnailImage = "#",
            ShoeName = "Test"
        };

        var shoe2 = new Domain.Entities.Shoe()
        {
            Id = 2,
            Brand = "Test2",
            CurrentPrice = 12,
            Quantity = 12,
            ThumbnailImage = "##",
            ShoeName = "Test2"
        };

        var user = new User()
        {
            Id = 1,
            Username = "Test",
        };

        cartRepository.Setup(c => c.GetCartByUserId(1)).ReturnsAsync(userCarts);
        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync(user);
        shoeRepository.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(shoe1);
        shoeRepository.Setup(s => s.GetByIdAsync(2)).ReturnsAsync(shoe2);

        var dtos = new List<GetCartDto>()
        {
            new GetCartDto()
            {
                ShoeId = 1,
                Brand = "Test",
                CurrentPrice = 10,
                Quantity = 10,
                ThumbnailImage = "#",
                ShoeName = "Test"
            },
            new GetCartDto()
            {
                ShoeId = 2,
                Brand = "Test2",
                CurrentPrice = 12,
                Quantity = 12,
                ThumbnailImage = "##",
                ShoeName = "Test2"
            },
        };

        var handler =
            new GetItemsFromCartQueryHandler(cartRepository.Object, userRepository.Object, shoeRepository.Object);

        //act

        var result = await handler.Handle(new GetItemsFromCartQuery(), CancellationToken.None);

        //assert 

        result.Should().BeEquivalentTo(dtos);
    }
}