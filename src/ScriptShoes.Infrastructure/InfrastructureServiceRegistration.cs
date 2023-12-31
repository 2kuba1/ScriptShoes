﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Infrastructure.Database;
using ScriptShoes.Infrastructure.Repositories;
using ScriptShoes.Infrastructure.Services;
using Stripe;

namespace ScriptShoes.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<IPaymentsService, PaymentsService>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnectionString"));
        });

        services.AddScoped<DatabaseSeeder>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IShoeRepository, ShoeRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IReviewLikeRepository, ReviewLikeRepository>();
        services.AddScoped<IEmailCodesRepository, EmailCodesRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderAddressRepository, OrderAddressRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();

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
    }
}