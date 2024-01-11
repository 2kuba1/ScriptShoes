using FluentAssertions;
using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Orders.Queries.GetPagedOrders;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests.Orders.Queries;

public class GetPagedOrdersQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForGivenData_ReturnsPagedOrders()
    {
        //arrange

        var query = new GetPagedOrdersQuery(1, 3);

        var orderRepository = new Mock<IOrderRepository>();

        var orders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                OrderAddress = new OrderAddress()
                {
                    Id = 1,
                    City = "Test",
                    Street = "Test",
                    PostalCode = "Test",
                    OrderSessionId = "Test"
                },
                Shoe = new Domain.Entities.Shoe()
                {
                    ShoeName = "Test"
                },
                OrderAddressId = 1
            },
            new Order()
            {
                Id = 2,
                OrderAddress = new OrderAddress()
                {
                    Id = 2,
                    City = "Test",
                    Street = "Test",
                    PostalCode = "Test",
                    OrderSessionId = "Test"
                },
                Shoe = new Domain.Entities.Shoe()
                {
                    ShoeName = "Test"
                },
                OrderAddressId = 2
            },
            new Order()
            {
                Id = 3,
                OrderAddress = new OrderAddress()
                {
                    Id = 3,
                    City = "Test",
                    Street = "Test",
                    PostalCode = "Test",
                    OrderSessionId = "Test"
                },
                Shoe = new Domain.Entities.Shoe()
                {
                    ShoeName = "Test"
                },
                OrderAddressId = 3
            }
        };

        var dto = new List<PagedOrdersDto>()
        {
            new PagedOrdersDto()
            {
                GetOrdersDto = new GetOrdersDto()
                {
                    Id = 1,
                    OrderAddressId = 1,
                    ShoeName = "Test"
                },
                City = "Test",
                Street = "Test",
                PostalCode = "Test"
            },
            new PagedOrdersDto()
            {
                GetOrdersDto = new GetOrdersDto()
                {
                    Id = 2,
                    OrderAddressId = 2,
                    ShoeName = "Test"
                },
                City = "Test",
                Street = "Test",
                PostalCode = "Test"
            },
            new PagedOrdersDto()
            {
                GetOrdersDto = new GetOrdersDto()
                {
                    Id = 3,
                    OrderAddressId = 3,
                    ShoeName = "Test"
                },
                City = "Test",
                Street = "Test",
                PostalCode = "Test"
            }
        };

        var pagedResult = new PagedResult<PagedOrdersDto>(dto, 3, 3, 1)
        {
            TotalPages = 3,
            ItemsFrom = 3
        };

        orderRepository.Setup(o => o.GetPagedOrders(1, 3)).ReturnsAsync(orders);

        var handler = new GetPagedOrdersQueryHandler(orderRepository.Object);

        //act

        var result = await handler.Handle(query, CancellationToken.None);

        //assert

        result.Should().BeEquivalentTo(pagedResult);
    }
}