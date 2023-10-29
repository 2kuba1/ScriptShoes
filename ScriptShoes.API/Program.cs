using System.Globalization;
using System.Threading.RateLimiting;
using NLog;
using NLog.Web;
using ScriptShoes.API.BackgroundServices;
using ScriptShoes.API.Middlewares;
using ScriptShoes.Application;
using ScriptShoes.Infrastructure;
using ScriptShoes.Persistence;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddRateLimiter(_ =>
    {
        _.OnRejected = (context, _) =>
        {
            if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
            {
                context.HttpContext.Response.Headers.RetryAfter =
                    ((int)retryAfter.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.", cancellationToken: _);

            return new ValueTask();
        };

        _.GlobalLimiter = PartitionedRateLimiter.CreateChained(
            PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var userAgent = httpContext.Request.Headers.UserAgent.ToString();

                return RateLimitPartition.GetFixedWindowLimiter
                (userAgent, _ =>
                    new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 4,
                        Window = TimeSpan.FromSeconds(2)
                    });
            }),
            PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var userAgent = httpContext.Request.Headers.UserAgent.ToString();

                return RateLimitPartition.GetFixedWindowLimiter
                (userAgent, _ =>
                    new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 20,
                        Window = TimeSpan.FromSeconds(30)
                    });
            }));
    });
// Add services to the container.

    builder.Services.AddApplicationServices();
    builder.Services.AddPersistenceServices(builder.Configuration);
    builder.Services.AddInfrastructureServices(builder.Configuration);

    builder.Services.AddScoped<ErrorHandlingMiddleware>();

    builder.Services.AddControllers();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddResponseCaching();

    builder.Services.AddCors(cfg =>
    {
        cfg.AddPolicy("ui", policy =>
        {
            policy.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AuthUser", b => b.RequireClaim("Role", "User", "Admin"));
    });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AuthAdmin", b => b.RequireClaim("Role", "Admin"));
    });

    builder.Services.AddHostedService<RemoveEmailCodesWorker>();
    
    var app = builder.Build();

    app.UseRateLimiter();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseCors("ui");

    app.UseResponseCaching();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}