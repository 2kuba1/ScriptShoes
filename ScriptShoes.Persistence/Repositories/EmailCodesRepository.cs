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

    public async Task RemoveRange(IEnumerable<EmailCode> codes)
    {
        _context.EmailCodes.RemoveRange(codes);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<EmailCode> GetExpiredCodes()
    {
        var expiredCodes = _context.EmailCodes.Where(x => x.Expires < DateTime.UtcNow).ToList();
        return expiredCodes;
    }

    public async Task<bool> GetByUserIdAndCode(int userId, string code)
    {
        var doesCodeExists = await _context.EmailCodes.AnyAsync(x => x.UserId == userId && x.Code == code);
        return doesCodeExists;
    }
}