using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Models.Token;

namespace ScriptShoes.Application.Features.User.Queries.RefreshToken;

public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, AccessToken>
{
    private readonly IAuthenticationService _service;
    private readonly IUserRepository _repository;

    public RefreshTokenQueryHandler(IAuthenticationService service, IUserRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    public async Task<AccessToken> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var newAccessToken = await _service.RefreshAccessToken(request.RefreshToken);

        return new AccessToken()
        {
            Token = newAccessToken.Token,
            Expires = newAccessToken.Expires
        };
    }
}