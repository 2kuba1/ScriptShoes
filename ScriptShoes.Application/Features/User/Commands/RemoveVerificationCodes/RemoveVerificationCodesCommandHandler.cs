using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.User.Commands.RemoveVerificationCodes;

public class RemoveVerificationCodesCommandHandler : IRequestHandler<RemoveVerificationCodesCommand, Unit>
{
    private readonly IEmailCodesRepository _emailCodesRepository;

    public RemoveVerificationCodesCommandHandler(IEmailCodesRepository emailCodesRepository)
    {
        _emailCodesRepository = emailCodesRepository;
    }

    public async Task<Unit> Handle(RemoveVerificationCodesCommand request, CancellationToken cancellationToken)
    {
        await _emailCodesRepository.RemoveRange(request.Codes);
        return Unit.Value;
    }
}