using MediatR;
using ScriptShoes.Application.Contracts.Infrastructure;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.User;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDto>
{
    private readonly IUserRepository _repository;
    private readonly IAuthenticationTokenMethods _tokenMethods;

    public LoginQueryHandler(IUserRepository repository, IAuthenticationTokenMethods tokenMethods)
    {
        _repository = repository;
        _tokenMethods = tokenMethods;
    }

    public async Task<LoginResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByEmailAndPassword(request.Dto.Email, request.Dto.Password);

        if (user is null)
            throw new BadRequestException("Email or password is incorrect");

        var accessToken = _tokenMethods.CreateAccessToken(user);
        var refreshToken = await _tokenMethods.CreateRefreshToken(user);

        return new LoginResponseDto()
        {
            AccessToken = accessToken.Token,
            RefreshToken = refreshToken.Token,
            AccessTokenExpirationTime = accessToken.Expires,
            RefreshTokenExpirationTime = refreshToken.Expires
        };
    }
}