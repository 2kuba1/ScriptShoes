using MediatR;
using ScriptShoes.Application.Models.Token;

namespace ScriptShoes.Application.Features.User.Queries.RefreshToken;

public record RefreshTokenQuery(string RefreshToken) : IRequest<AccessToken>;