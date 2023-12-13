using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.Token;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;
using IAuthenticationService = ScriptShoes.Application.Contracts.Services.IAuthenticationService;

namespace ScriptShoes.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AuthenticationService(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public AccessToken CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Username", user.Username),
            new Claim("FirstName", $"{user.FirstName}"),
            new Claim("LastName", $"{user.LastName}"),
            new Claim("Email", $"{user.Email}"),
            new Claim("ProfilePicture", user.ProfilePictureUrl),
            new Claim("IsVerified", user.IsVerified.ToString()),
            new Claim("Role", $"{user.Role.Name}"),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key") ??
                                                                  string.Empty));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:ExpireMinutes"));

        var token = new JwtSecurityToken(_configuration.GetValue<string>("Jwt:Issuer"),
            _configuration.GetValue<string>("Jwt:Audience"),
            claims: claims,
            DateTime.UtcNow,
            expires,
            credentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new AccessToken()
        {
            Token = accessToken,
            Expires = expires
        };
    }

    public async Task<RefreshToken> CreateRefreshToken(User user)
    {
        var refreshToken = new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:RefreshKeyExpireHours")),
        };

        user.RefreshToken = refreshToken.Token;
        user.RefreshTokenExpirationTime = refreshToken.Expires;

        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();

        return refreshToken;
    }

    public async Task<AccessToken> RefreshAccessToken(string refreshToken)
    {
        var user = await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

        if (user is null)
            throw new BadRequestException("Invalid refresh token");

        if (refreshToken != user.RefreshToken && user.RefreshTokenExpirationTime < DateTime.UtcNow)
            throw new BadRequestException("Invalid refresh token");

        return CreateAccessToken(user);
    }
}