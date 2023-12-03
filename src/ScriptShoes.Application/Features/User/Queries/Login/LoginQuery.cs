using MediatR;
using ScriptShoes.Application.Models.User;

namespace ScriptShoes.Application.Features.User.Queries.Login;

public record LoginQuery(LoginDto Dto) : IRequest<LoginResponseDto>;