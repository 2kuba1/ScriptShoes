using MediatR;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveShoeFromDiscount;

public record RemoveShoeFromDiscountCommand(int ShoeId) : IRequest<Unit>;