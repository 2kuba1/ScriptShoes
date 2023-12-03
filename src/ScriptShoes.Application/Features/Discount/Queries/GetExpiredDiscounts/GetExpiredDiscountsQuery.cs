using MediatR;

namespace ScriptShoes.Application.Features.Discount.Queries.GetExpiredDiscounts;

public record GetExpiredDiscountsQuery() : IRequest<List<Domain.Entities.Discount>>;