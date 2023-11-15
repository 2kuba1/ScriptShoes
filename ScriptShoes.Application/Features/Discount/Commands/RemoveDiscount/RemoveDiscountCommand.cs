using MediatR;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveDiscount;

public record RemoveDiscountCommand(int DiscountId) : IRequest<Unit>;