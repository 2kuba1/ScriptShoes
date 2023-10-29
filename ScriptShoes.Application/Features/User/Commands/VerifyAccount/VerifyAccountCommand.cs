using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.VerifyAccount;

public record VerifyAccountCommand(string Code) : IRequest<Unit>;