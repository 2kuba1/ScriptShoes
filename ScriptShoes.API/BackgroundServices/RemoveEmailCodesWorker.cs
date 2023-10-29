using MediatR;
using ScriptShoes.Application.Features.User.Commands.RemoveVerificationCodes;
using ScriptShoes.Application.Features.User.Queries.GetExpiredCodes;

namespace ScriptShoes.API.BackgroundServices;

public class RemoveEmailCodesWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger _logger;

    public RemoveEmailCodesWorker(IServiceScopeFactory serviceScopeFactory, ILogger logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            try
            {
                var expiredCodes = await mediator.Send(new GetExpiredCodesQuery(), stoppingToken);

                expiredCodes.ForEach(x =>
                    _logger.LogInformation(
                        $"Email code with id {x.Id} assigned to user with id {x.UserId} has been removed"));

                await mediator.Send(new RemoveVerificationCodesCommand(expiredCodes), stoppingToken);
                await Task.Delay(30 * 60 * 1000, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}