using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;
using BC = BCrypt.Net.BCrypt;

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

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
            return null;

        var isPasswordCorrect = BC.Verify(password, user.HashedPassword);

        Console.WriteLine(isPasswordCorrect);

        return isPasswordCorrect ? user : null;
    }
}