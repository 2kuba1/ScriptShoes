using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IEmailCodesRepository : IGenericRepository<EmailCode>
{
    Task<bool> DoesUserHaveACode(int userId);
    Task RemoveRange(IEnumerable<EmailCode> codes);
    IEnumerable<EmailCode> GetExpiredCodes();
    Task<bool> CheckIfCodeWithUserIdExist(int userId, string code);
    Task<EmailCode?> GetCodeByUserId(int userId);
}