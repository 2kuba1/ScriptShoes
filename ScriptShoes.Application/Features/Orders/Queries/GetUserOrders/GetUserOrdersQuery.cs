using MediatR;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Features.Orders.Queries.GetUserOrders;

public record GetUserOrdersQuery(int PageSize, int PageNumber) : IRequest<PagedResult<UserOrdersDto>>;