using MediatR;
using ScriptShoes.Application.Models.User;

namespace ScriptShoes.Application.Features.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDto>
{
    public async Task<LoginResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}