using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;
using ScriptShoes.Infrastructure.Repositories;
using Shouldly;

namespace ScriptShoes.PersistenceTests.RepositoriesTests;

public class ShoeRepositoryTests
{
    private readonly IShoeRepository _shoeRepository;
    private readonly AppDbContext _context;

    public ShoeRepositoryTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _context = new AppDbContext(dbOptions, true);

        DatabaseSeeder.SeedDatabase(_context);

        _shoeRepository = new ShoeRepository(new AppDbContext(dbOptions, true));
    }

    [Fact]
    public async Task Get_By_Name()
    {
        var shoe = await _shoeRepository.GetByNameAsync("Chron");

        shoe.ShouldBeOfType<Shoe>();
        shoe.ShouldNotBeNull();
    }
}