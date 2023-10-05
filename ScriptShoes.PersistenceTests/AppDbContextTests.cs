using Microsoft.EntityFrameworkCore;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;
using Shouldly;

namespace ScriptShoes.PersistenceTests;

public class AppDbContextTests
{
    private readonly AppDbContext _dbContext;
    
    public AppDbContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _dbContext = new AppDbContext(dbOptions, true);
    }
    
    [Fact]
    public async Task Save_Create_Date()
    {
        var favorite = new Favorite()
        {
            Id = 1,
            ShoeId = 1,
            UserId = 1,
        };

        await _dbContext.Favorites.AddAsync(favorite);
        await _dbContext.SaveChangesAsync();
        
        favorite.Created.ShouldBeOfType<DateTime>();
        favorite.Created.ShouldBeLessThan(DateTime.UtcNow);
    }

    [Fact]
    public async Task Modify_Create_Date()
    {
        var favorite = new Favorite()
        {
            Id = 1,
            ShoeId = 1,
            UserId = 1,
        };

        await _dbContext.Favorites.AddAsync(favorite);
        await _dbContext.SaveChangesAsync();
        
        favorite.LastModified.ShouldBeOfType<DateTime>();
        favorite.LastModified.ShouldBeLessThan(DateTime.UtcNow);
    }
}