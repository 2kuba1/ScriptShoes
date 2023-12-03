using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Commands.CheckoutPayment;

public class CheckoutPaymentCommandHandler : IRequestHandler<CheckoutPaymentCommand, string>
{
    private readonly IPaymentsService _paymentsService;
    private readonly IShoeRepository _shoeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderAddressRepository _orderAddressRepository;

    public CheckoutPaymentCommandHandler(IPaymentsService paymentsService, IShoeRepository shoeRepository,
        IUserRepository userRepository, IOrderAddressRepository orderAddressRepository)
    {
        _paymentsService = paymentsService;
        _shoeRepository = shoeRepository;
        _userRepository = userRepository;
        _orderAddressRepository = orderAddressRepository;
    }

    public async Task<string> Handle(CheckoutPaymentCommand request, CancellationToken cancellationToken)
    {
        var createCheckoutData = new List<CreateCheckoutDto>();

        foreach (var data in request.Dto.Items)
        {
            var shoe = await _shoeRepository.GetByIdAsync(data.ShoeId);

            if (shoe is null)
                throw new NotFoundException($"Shoe with id {data.ShoeId} not found");

            if (shoe.Quantity - data.Quantity < 0)
                throw new BadRequestException("There are not enough items in stock");

            createCheckoutData.Add(new CreateCheckoutDto()
            {
                Shoe = shoe,
                Quantity = data.Quantity
            });

            shoe.Quantity -= data.Quantity;
            await _shoeRepository.UpdateAsync(shoe);
        }

        var response = new CreateCheckoutSessionResponseDto();

        try
        {
            var user = _userRepository.GetUserId;

            if (user is not null)
            {
                response = await _paymentsService.CreateCheckoutSession(createCheckoutData, user.Value);
            }
        }
        catch (NullReferenceException e)
        {
            response = await _paymentsService.CreateCheckoutSession(createCheckoutData, null);
        }

        if (string.IsNullOrEmpty(response.Url)) throw new Exception();

        var order = request.Dto.Address.Adapt<OrderAddress>();
        order.OrderSessionId = response.SessionId;
        await _orderAddressRepository.CreateAsync(order);

        return response.Url;
    }
}