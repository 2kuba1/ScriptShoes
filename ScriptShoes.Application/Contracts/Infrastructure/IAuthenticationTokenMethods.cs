using ScriptShoes.Application.Models.Token;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Infrastructure;

public interface IAuthenticationTokenMethods
{
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user);
}