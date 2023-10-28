﻿using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IEmailCodesRepository : IGenericRepository<EmailCode>
{
    Task<bool> DoesUserHaveACode(int userId);
}