using MediatR;
using ScriptShoes.Application.Models.Discount;

namespace ScriptShoes.Application.Features.Discount.Commands.CreateDiscount;

public record CreateDiscountCommand(CreateDiscountDto Dto) : IRequest<Unit>;