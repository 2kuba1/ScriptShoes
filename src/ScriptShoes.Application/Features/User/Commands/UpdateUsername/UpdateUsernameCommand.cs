using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.UpdateUsername;

public record UpdateUsernameCommand(string NewUsername) : IRequest<Unit>;