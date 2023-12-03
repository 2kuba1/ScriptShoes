using MediatR;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.User.Commands.RemoveVerificationCodes;

public record RemoveVerificationCodesCommand(List<EmailCode> Codes) : IRequest<Unit>;