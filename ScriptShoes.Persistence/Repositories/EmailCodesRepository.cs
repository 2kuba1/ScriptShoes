using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class EmailCodesRepository : GenericRepository<EmailCode>, IEmailCodesRepository
{
    public EmailCodesRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<bool> DoesUserHaveACode(int userId)
    {
        var code = await _context.EmailCodes.AnyAsync(x => x.UserId == userId);
        return code;
    }
}