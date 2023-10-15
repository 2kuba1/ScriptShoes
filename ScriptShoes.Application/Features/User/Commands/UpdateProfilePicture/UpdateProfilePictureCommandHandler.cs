using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.User.Commands.UpdateProfilePicture;

public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, Unit>
{
    private readonly IUserRepository _repository;

    public UpdateProfilePictureCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_repository);

        user.ProfilePictureUrl = request.ImageUrl;

        await _repository.UpdateAsync(user);

        return Unit.Value;
    }
}