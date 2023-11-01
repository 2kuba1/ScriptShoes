using MediatR;
using ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;
using ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrdersAddresses;
using ScriptShoes.Application.Features.Orders.Queries.GetExpiredOrders;

namespace ScriptShoes.API.BackgroundServices;

public class RemoveExpiredOrdersWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RemoveExpiredOrdersWorker(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            try
            {
                var expiredOrders = await mediator.Send(new GetExpiredOrdersQuery(), stoppingToken);
                await mediator.Send(new RemoveExpiredOrdersAddressesCommand(expiredOrders), stoppingToken);
                await mediator.Send(new RemoveExpiredOrdersCommand(expiredOrders), stoppingToken);
                await Task.Delay(5 * 60 * 1000, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}