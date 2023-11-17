using MediatR;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveExpiredDiscounts;

public record RemoveExpiredDiscountsCommand(IEnumerable<Domain.Entities.Discount> Discounts) : IRequest<Unit>;