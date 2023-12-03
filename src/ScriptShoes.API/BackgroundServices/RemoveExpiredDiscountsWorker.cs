using MediatR;
using ScriptShoes.Application.Features.Discount.Commands.RemoveExpiredDiscounts;
using ScriptShoes.Application.Features.Discount.Queries.GetExpiredDiscounts;

namespace ScriptShoes.API.BackgroundServices;

public class RemoveExpiredDiscountsWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RemoveExpiredDiscountsWorker(IServiceScopeFactory serviceScopeFactory)
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
                var expiredDiscounts = await mediator.Send(new GetExpiredDiscountsQuery(), stoppingToken);
                await mediator.Send(new RemoveExpiredDiscountsCommand(expiredDiscounts), stoppingToken);
                await Task.Delay(5 * 60 * 30, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}