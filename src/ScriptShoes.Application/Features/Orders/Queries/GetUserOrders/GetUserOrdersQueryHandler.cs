﻿using Mapster;
using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Queries.GetUserOrders;

public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, PagedResult<UserOrdersDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderAddressRepository _orderAddressRepository;
    private readonly TypeAdapterConfig _typeAdapterConfig;

    public GetUserOrdersQueryHandler(IUserRepository userRepository, IOrderRepository orderRepository,
        IOrderAddressRepository orderAddressRepository)
    {
        _userRepository = userRepository;
        _orderRepository = orderRepository;
        _orderAddressRepository = orderAddressRepository;
        _typeAdapterConfig = GetTypeAdapterConfig();
    }

    public async Task<PagedResult<UserOrdersDto>> Handle(GetUserOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);

        var orders = await _orderRepository.GetUserOrders(user.Id, request.PageSize, request.PageNumber);

        var userOrders = new List<UserOrdersDto>();

        foreach (var order in orders)
        {
            var address = await _orderAddressRepository.GetOrderAddressBySessionId(order.SessionId);

            if (address is null)
                continue;

            var newOrder = order.Adapt<UserOrdersDto>(_typeAdapterConfig);
            userOrders.Add(newOrder);
        }


        return new PagedResult<UserOrdersDto>(userOrders, orders.Count, request.PageSize, request.PageNumber);
    }

    private static TypeAdapterConfig GetTypeAdapterConfig()
    {
        var config = new TypeAdapterConfig();

        config.NewConfig<Order, UserOrdersDto>()
            .Map(dest => dest.Brand, src => src.Shoe.Brand)
            .Map(dest => dest.ShoeName, src => src.Shoe.ShoeName)
            .Map(dest => dest.ThumbnailImage, src => src.Shoe.ThumbnailImage);

        return config;
    }
}