using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.User.Commands.AddProfilePicture;

public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, Unit>
{
    private readonly IUserRepository _repository;

    public UpdateProfilePictureCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
    {
        if (_repository.GetUserId is null)
            throw new NotFoundException("User not found");

        var user = await _repository.GetByIdAsync(_repository.GetUserId.Value);

        if (user is null)
            throw new NotFoundException("User not found");

        user.ProfilePictureUrl = request.ImageUrl;

        await _repository.UpdateAsync(user);

        return Unit.Value;
    }
}