using MediatR;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Queries.GetExpiredOrders;

public record GetExpiredOrdersQuery() : IRequest<List<Order>>;