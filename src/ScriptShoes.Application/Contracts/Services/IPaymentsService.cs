using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Contracts.Services;

public interface IPaymentsService
{
    Task<CreateCheckoutSessionResponseDto> CreateCheckoutSession(List<CreateCheckoutDto> dto, int? userId);
    Task ConfirmOrder(string sessionId);
}