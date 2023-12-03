using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Contracts.Infrastructure.StripePayments;

public interface IStripePayments
{
    Task<CreateCheckoutSessionResponseDto> CreateCheckoutSession(List<CreateCheckoutDto> dto, int? userId);
    Task ConfirmOrder(string sessionId);
}