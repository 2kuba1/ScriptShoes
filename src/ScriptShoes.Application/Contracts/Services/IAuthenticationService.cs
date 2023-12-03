using ScriptShoes.Application.Models.Token;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Services;

public interface IAuthenticationService
{
    public AccessToken CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user);
    public Task<AccessToken> RefreshAccessToken(string refreshToken);
}