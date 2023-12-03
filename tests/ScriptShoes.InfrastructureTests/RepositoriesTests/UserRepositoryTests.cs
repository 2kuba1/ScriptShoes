using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Infrastructure.Database;
using ScriptShoes.Infrastructure.Repositories;
using Shouldly;

namespace ScriptShoes.PersistenceTests.RepositoriesTests;

public class UserRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly UserRepository _userRepository;


    public UserRepositoryTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _context = new AppDbContext(dbOptions, true);

        DatabaseSeeder.SeedDatabase(_context);

        _userRepository = new UserRepository(new AppDbContext(dbOptions, true), new HttpContextAccessor());
    }

    [Fact]
    public async Task Is_User_Name_Equal()
    {
        const string name = "2kuba1";

        var isUserNameEqual = await _userRepository.IsUserNameEqual(name);

        isUserNameEqual.ShouldBeOfType<bool>();
        isUserNameEqual.ShouldBeEquivalentTo(true);
    }

    [Fact]
    public async Task Is_Email_Equal()
    {
        const string email = "kuba@gmail.com";

        var isEmailEqual = await _userRepository.IsEmailEqual(email);

        isEmailEqual.ShouldBeOfType<bool>();
        isEmailEqual.ShouldBeEquivalentTo(true);
    }
}