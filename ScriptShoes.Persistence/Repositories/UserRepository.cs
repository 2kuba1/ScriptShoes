using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsUserNameEqual(string name)
    {
        var isUsernameEqual = await _context.Users.AnyAsync(x => x.Username == name);
        return isUsernameEqual;
    }

    public async Task<bool> IsEmailEqual(string email)
    {
        var isEmailEqual = await _context.Users.AnyAsync(x => x.Email == email);
        return isEmailEqual;
    }
}