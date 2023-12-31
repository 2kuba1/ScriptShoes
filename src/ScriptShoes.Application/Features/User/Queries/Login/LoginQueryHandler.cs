﻿using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.User;

namespace ScriptShoes.Application.Features.User.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDto>
{
    private readonly IUserRepository _repository;
    private readonly IAuthenticationService _service;

    public LoginQueryHandler(IUserRepository repository, IAuthenticationService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<LoginResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByEmailAndPassword(request.Dto.Email, request.Dto.Password);

        if (user is null)
            throw new BadRequestException("Email or password is incorrect");

        var accessToken = _service.CreateAccessToken(user);
        var refreshToken = await _service.CreateRefreshToken(user);

        return new LoginResponseDto()
        {
            AccessToken = accessToken.Token,
            RefreshToken = refreshToken.Token,
            AccessTokenExpirationTime = accessToken.Expires,
            RefreshTokenExpirationTime = refreshToken.Expires
        };
    }
}