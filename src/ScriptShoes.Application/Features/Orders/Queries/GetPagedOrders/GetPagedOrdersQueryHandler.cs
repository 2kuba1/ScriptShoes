using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Queries.GetPagedOrders;

public class GetPagedOrdersQueryHandler : IRequestHandler<GetPagedOrdersQuery, PagedResult<PagedOrdersDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetPagedOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<PagedResult<PagedOrdersDto>> Handle(GetPagedOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetPagedOrders(request.PageSize, request.PageNumber);
        
        var totalItemsCount = orders.Count;
        
        TypeAdapterConfig config = new();
        
        config.NewConfig<Order, PagedOrdersDto>()
            .Map(dest => dest.GetOrdersDto.Brand, src => src.Shoe.Brand)
            .Map(dest => dest.GetOrdersDto.ShoeName, src => src.Shoe.ShoeName)
            .Map(dest => dest.GetOrdersDto.CurrentPrice, src => src.Shoe.CurrentPrice)
            .Map(dest => dest.GetOrdersDto.ThumbnailImage, src => src.Shoe.ThumbnailImage)
            .Map(dest => dest.GetOrdersDto.Id, src => src.Id)
            .Map(dest => dest.GetOrdersDto.Quantity, src => src.Quantity)
            .Map(dest => dest.GetOrdersDto.ShoeId, src => src.ShoeId)
            .Map(dest => dest.City, src => src.OrderAddress.City)
            .Map(dest => dest.GetOrdersDto.OrderAddressId, src => src.OrderAddress.Id)
            .Map(dest => dest.Street, src => src.OrderAddress.Street)
            .Map(dest => dest.PostalCode, src => src.OrderAddress.PostalCode);
        
        var mappedValues = orders.Adapt<List<PagedOrdersDto>>(config);
        
        return new PagedResult<PagedOrdersDto>(mappedValues, totalItemsCount, request.PageSize, request.PageNumber);
        
    }
}