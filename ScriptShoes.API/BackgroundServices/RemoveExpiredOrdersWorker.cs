using MediatR;
using ScriptShoes.Application.Features.Payments.Commands.RemoveExpiredOrders;

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
                await mediator.Send(new RemoveExpiredOrdersCommand(), stoppingToken);
                await Task.Delay(5 * 60 * 1000, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}