using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task<IEnumerable<EmailCode>> GetExpiredCodes()
    {
        var expiredCodes = await _context.EmailCodes.Where(x => x.Expires < DateTime.UtcNow).ToListAsync();
        return expiredCodes;
    }

    public async Task<bool> CheckIfCodeWithUserIdExist(int userId, string code)
    {
        var doesCodeExists = await _context.EmailCodes.AnyAsync(x => x.UserId == userId && x.Code == code);
        return doesCodeExists;
    }

    public async Task<EmailCode?> GetCodeByUserId(int userId)
    {
        var code = await _context.EmailCodes.FirstOrDefaultAsync(x => x.UserId == userId);
        return code;
    }
}