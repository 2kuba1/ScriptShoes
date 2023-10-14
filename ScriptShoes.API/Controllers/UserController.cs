using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.User.Commands.Register;
using ScriptShoes.Application.Features.User.Queries.Login;
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
}