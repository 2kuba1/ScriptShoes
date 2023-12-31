﻿using System.Security.Claims;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> IsUserNameEqual(string name);
    public Task<bool> IsEmailEqual(string email);
    public Task<User?> GetUserByEmailAndPassword(string email, string password);
    public string? GetUserNameById(int id);
    ClaimsPrincipal User { get; }
    int? GetUserId { get; }
}