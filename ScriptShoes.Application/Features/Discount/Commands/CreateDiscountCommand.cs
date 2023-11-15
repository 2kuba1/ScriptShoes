using MediatR;
using ScriptShoes.Application.Models.Discount;

namespace ScriptShoes.Application.Features.Discount.Commands;

public record CreateDiscountCommand(CreateDiscountDto Dto) : IRequest<Unit>;