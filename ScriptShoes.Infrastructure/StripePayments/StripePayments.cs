using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScriptShoes.Application.Contracts.Infrastructure.StripePayments;
using ScriptShoes.Application.Models.Payments;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Exceptions;
using ScriptShoes.Persistence.Database;
using Stripe.Checkout;

namespace ScriptShoes.Infrastructure.StripePayments;

public class StripePayments : IStripePayments
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _dbContext;

    public StripePayments(IConfiguration configuration, AppDbContext dbContext)
    {
        _configuration = configuration;
        _dbContext = dbContext;
    }

    public async Task<string> CreateCheckoutSession(List<CreateCheckoutDto> dto, int? userId)
    {
        try
        {
            var options = new SessionCreateOptions()
            {
                SuccessUrl = _configuration.GetSection("Stripe:SuccessPageUrl").Get<string>(),
                CancelUrl = _configuration.GetSection("Stripe:CancelPage").Get<string>(),
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                ExpiresAt = DateTime.UtcNow + TimeSpan.FromMinutes(30)
            };

            var orders = new List<Order>();

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
                orders.Add(new Order()
                {
                    Quantity = data.Quantity,
                    ShoeId = data.Shoe.Id,
                    UserId = userId,
                    SessionExpirationDateTime = DateTime.UtcNow + TimeSpan.FromMinutes(30)
                });
                options.LineItems.Add(sessionListItem);
            });

            var service = new SessionService();

            var session = await service.CreateAsync(options);

            foreach (var order in orders)
            {
                order.SessionId = session.Id;
            }

            await _dbContext.Orders.AddRangeAsync(orders);
            await _dbContext.SaveChangesAsync();

            return session.Url;
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong");
        }
    }

    public async Task ConfirmOrder(string sessionId)
    {
        var order = _dbContext.Orders.Where(x => x.SessionId == sessionId).ToList();

        if (order is null)
            throw new NotFoundException("Order not found");

        order.ForEach(x => x.IsConfirmed = true);

        _dbContext.Orders.UpdateRange(order);
        await _dbContext.SaveChangesAsync();
    }
}