using MediatR;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Features.Orders.Queries.GetPagedOrders;

public record GetPagedOrdersQuery(int PageSize, int PageNumber) : IRequest<PagedResult<PagedOrdersDto>>;