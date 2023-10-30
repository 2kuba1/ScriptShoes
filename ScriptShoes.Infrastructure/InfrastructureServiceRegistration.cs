using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ScriptShoes.Application.Contracts.Infrastructure;
using ScriptShoes.Application.Contracts.Infrastructure.Email;
using ScriptShoes.Application.Contracts.Infrastructure.StripePayments;
using ScriptShoes.Infrastructure.AuthenticationTokens;
using Stripe;

namespace ScriptShoes.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IAuthenticationTokenMethods, TokenMethods>();
        services.AddScoped<IEmailSender, EmailSender.EmailSender>();
        services.AddScoped<IStripePayments, StripePayments.StripePayments>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        StripeConfiguration.ApiKey = configuration.GetSection("Stripe:SecretKey").Get<string>();

        return services;
    }
}