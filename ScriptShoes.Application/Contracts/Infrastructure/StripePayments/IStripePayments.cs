using ScriptShoes.Application.Models.Payments;

namespace ScriptShoes.Application.Contracts.Infrastructure.StripePayments;

public interface IStripePayments
{
    Task<string> CreateCheckoutSession(List<CreateCheckoutDto> dto);
}