using FluentValidation;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.API.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            _logger.LogInformation($"{context.Request.Path} has been invoked");
            await next(context);
        }
        catch (ValidationException e)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(e.Errors);
        }
        catch (BadRequestException e)
        {
            context.Response.StatusCode = 400;
            _logger.LogInformation(e.Message);
            await context.Response.WriteAsJsonAsync(e.Message);
        }
        catch (NotFoundException e)
        {
            context.Response.StatusCode = 404;
            _logger.LogInformation(e.Message);
            await context.Response.WriteAsJsonAsync(e.Message);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            _logger.LogCritical(e.Message);
            await context.Response.WriteAsJsonAsync("Internal Server Error");
        }
    }
}