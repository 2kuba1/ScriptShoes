using MediatR;
using ScriptShoes.Application.Models.User;

namespace ScriptShoes.Application.Features.User.Commands.Register;

public record RegisterCommand(RegisterDto Dto) : IRequest<Unit>;