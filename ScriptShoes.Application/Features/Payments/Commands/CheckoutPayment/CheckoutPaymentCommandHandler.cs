using MediatR;
using ScriptShoes.Application.Contracts.Infrastructure.StripePayments;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Payments;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Payments.Commands.CheckoutPayment;

public class CheckoutPaymentCommandHandler : IRequestHandler<CheckoutPaymentCommand, string>
{
    private readonly IStripePayments _stripePayments;
    private readonly IShoeRepository _shoeRepository;

    public CheckoutPaymentCommandHandler(IStripePayments stripePayments, IShoeRepository shoeRepository)
    {
        _stripePayments = stripePayments;
        _shoeRepository = shoeRepository;
    }

    public async Task<string> Handle(CheckoutPaymentCommand request, CancellationToken cancellationToken)
    {
        var createCheckoutData = new List<CreateCheckoutDto>();

        foreach (var data in request.Dto)
        {
            var shoe = await _shoeRepository.GetByIdAsync(data.ShoeId);

            if (shoe is null)
                throw new NotFoundException($"Shoe with id {data.ShoeId} not found");

            if (shoe.Quantity - data.Quantity < 0)
                throw new BadRequestException("TThere are not enough items in stock");

            createCheckoutData.Add(new CreateCheckoutDto()
            {
                Shoe = shoe,
                Quantity = data.Quantity
            });
        }

        var response = await _stripePayments.CreateCheckoutSession(createCheckoutData);
        return response;
    }
}