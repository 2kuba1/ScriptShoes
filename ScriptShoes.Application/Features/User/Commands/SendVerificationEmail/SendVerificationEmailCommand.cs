using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.SendVerificationEmail;

public record SendVerificationEmailCommand() : IRequest<Unit>;