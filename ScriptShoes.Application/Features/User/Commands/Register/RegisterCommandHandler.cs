using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;
using BC = BCrypt.Net.BCrypt;

namespace ScriptShoes.Application.Features.User.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IUserRepository _repository;

    public RegisterCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isUserNameEqual = await _repository.IsUserNameEqual(request.Dto.Username);

        if (isUserNameEqual)
            throw new BadRequestException("User with that username already exists");

        var isEmailEqual = await _repository.IsEmailEqual(request.Dto.Email);

        if (isEmailEqual)
            throw new BadRequestException("This email is already taken");

        var hashedPassword = BC.HashPassword(request.Dto.Password);

        var user = request.Dto.Adapt<Domain.Entities.User>();

        user.HashedPassword = hashedPassword;
        user.RoleId = 1;

        return Unit.Value;
    }
}