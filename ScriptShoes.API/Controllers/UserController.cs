using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ScriptShoes.Application.Features.User.Commands.Register;
using ScriptShoes.Application.Features.User.Commands.ResendVerificationEmail;
using ScriptShoes.Application.Features.User.Commands.SendVerificationEmail;
using ScriptShoes.Application.Features.User.Commands.UpdateProfilePicture;
using ScriptShoes.Application.Features.User.Commands.VerifyAccount;
using ScriptShoes.Application.Features.User.Queries.Login;
using ScriptShoes.Application.Features.User.Queries.RefreshToken;
using ScriptShoes.Application.Models.Token;
using ScriptShoes.Application.Models.User;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto dto)
    {
        await _mediator.Send(new RegisterCommand(dto));
        return NoContent();
    }

    [HttpGet]
    [Route("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromQuery] string email, [FromQuery] string password)
    {
        var response = await _mediator.Send(new LoginQuery(new LoginDto()
        {
            Email = email,
            Password = password
        }));

        return Ok(response);
    }

    [HttpGet]
    [Route("refreshToken")]
    public async Task<ActionResult<AccessToken>> RefreshToken([FromQuery] string refreshToken)
    {
        var accessToken = await _mediator.Send(new RefreshTokenQuery(refreshToken));
        return Ok(accessToken);
    }

    [HttpPut]
    [Route("updateProfilePicture")]
    [Authorize(Policy = "AuthUser")]
    public async Task<ActionResult> UpdateProfilePicture([FromBody] string imageUrl)
    {
        await _mediator.Send(new UpdateProfilePictureCommand(imageUrl));
        return NoContent();
    }

    [HttpPost]
    [Route("sendVerificationEmail")]
    [Authorize(Policy = "AuthUser")]
    public async Task<ActionResult> SendVerificationEmail()
    {
        await _mediator.Send(new SendVerificationEmailCommand());
        return NoContent();
    }

    [HttpPut]
    [Route("resendVerificationEmail")]
    [Authorize(Policy = "AuthUser")]
    [EnableRateLimiting("resendEmail")]
    public async Task<ActionResult> ResendVerificationEmail()
    {
        await _mediator.Send(new ResendVerificationEmailCommand());
        return NoContent();
    }

    [HttpPut]
    [Route("verifyUser")]
    [Authorize(Policy = "AuthUser")]
    public async Task<ActionResult> VerifyUser([FromQuery] string code)
    {
        await _mediator.Send(new VerifyAccountCommand(code));
        return NoContent();
    }
}