using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.User.Commands.VerifyAccount;

public class VerifyAccountCommandHandler : IRequestHandler<VerifyAccountCommand, Unit>
{
    private readonly IEmailCodesRepository _emailCodesRepository;
    private readonly IUserRepository _userRepository;

    public VerifyAccountCommandHandler(IEmailCodesRepository emailCodesRepository, IUserRepository userRepository)
    {
        _emailCodesRepository = emailCodesRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);

        if (user.IsVerified)
            throw new BadRequestException("This user is already verified");

        var code = await _emailCodesRepository.CheckIfCodeWithUserIdExist(user.Id, request.Code);

        if (!code)
            throw new NotFoundException("Code or user not found");

        user.IsVerified = true;
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}