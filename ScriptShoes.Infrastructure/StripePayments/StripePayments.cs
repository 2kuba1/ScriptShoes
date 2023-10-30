using Microsoft.Extensions.Configuration;
using ScriptShoes.Application.Contracts.Infrastructure.StripePayments;
using ScriptShoes.Application.Models.Payments;
using ScriptShoes.Domain.Entities;
using Stripe.Checkout;

namespace ScriptShoes.Infrastructure.StripePayments;

public class StripePayments : IStripePayments
{
    private readonly IConfiguration _configuration;

    public StripePayments(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> CreateCheckoutSession(List<CreateCheckoutDto> dto)
    {
        var options = new SessionCreateOptions()
        {
            SuccessUrl = _configuration.GetSection("Stripe:SuccessPageUrl").Get<string>(),
            CancelUrl = _configuration.GetSection("Stripe:CancelPage").Get<string>(),
            LineItems = new List<SessionLineItemOptions>(),
            Mode = "payment",
        };

        foreach (var shoe in dto)
        {
            Console.WriteLine(shoe.Shoe.ShoeName);
            Console.WriteLine(shoe.Quantity);
            Console.WriteLine(shoe.Shoe.ThumbnailImage);
            Console.WriteLine(shoe.Shoe.CurrentPrice);
        }

        dto.ForEach(data =>
        {
            var sessionListItem = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmount = (long)(data.Shoe.CurrentPrice * 100),
                    Currency = "pln",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = data.Shoe.ShoeName,
                        Images = data.Shoe.ThumbnailImage is null
                            ? new List<string>()
                            {
                                "https://cdn.discordapp.com/attachments/1107657664026116106/1146048155197124668/crimewitamy.png?ex=654a2384&is=6537ae84&hm=e31115a5808cbb615e1cff5bf3c6c0e31f371603f954e18f31feaeabaf7ad758&"
                            }
                            : new List<string>() { data.Shoe.ThumbnailImage }
                    }
                },
                Quantity = data.Quantity
            };
            options.LineItems.Add(sessionListItem);
        });

        var service = new SessionService();

        var session = await service.CreateAsync(options);
        return session.Url;
    }
}