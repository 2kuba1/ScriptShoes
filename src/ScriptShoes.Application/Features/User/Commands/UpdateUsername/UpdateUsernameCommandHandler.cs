using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Domain.ValueObjects.User;

namespace ScriptShoes.Application.Features.User.Commands.UpdateUsername;

public class UpdateUsernameCommandHandler : IRequestHandler<UpdateUsernameCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUsernameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsUserNameEqual(request.NewUsername))
            throw new BadRequestException($"Username '{request.NewUsername}' is already taken!");

        var user = await _userRepository.GetByIdAsync(_userRepository.GetUserId!.Value);

        if (user is null)
            throw new NotFoundException("User not found");

        user.Username = request.NewUsername;

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}