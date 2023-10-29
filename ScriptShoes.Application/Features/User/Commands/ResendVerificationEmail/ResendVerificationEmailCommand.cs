using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.ResendVerificationEmail;

public record ResendVerificationEmailCommand() : IRequest<Unit>;