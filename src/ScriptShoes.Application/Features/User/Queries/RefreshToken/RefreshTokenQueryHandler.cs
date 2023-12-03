using MediatR;
using ScriptShoes.Application.Contracts.Infrastructure;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Token;

namespace ScriptShoes.Application.Features.User.Queries.RefreshToken;

public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, AccessToken>
{
    private readonly IAuthenticationTokenMethods _tokenMethods;
    private readonly IUserRepository _repository;

    public RefreshTokenQueryHandler(IAuthenticationTokenMethods tokenMethods, IUserRepository repository)
    {
        _tokenMethods = tokenMethods;
        _repository = repository;
    }

    public async Task<AccessToken> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var newAccessToken = await _tokenMethods.RefreshAccessToken(request.RefreshToken);

        return new AccessToken()
        {
            Token = newAccessToken.Token,
            Expires = newAccessToken.Expires
        };
    }
}