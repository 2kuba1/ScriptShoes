using Microsoft.EntityFrameworkCore;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;
using ScriptShoes.Persistence.Repositories;
using Shouldly;

namespace ScriptShoes.PersistenceTests.RepositoriesTests;

public class GenericRepositoryTests
{
    private readonly GenericRepository<Shoe> _genericRepository;
    private readonly AppDbContext _context;

    public GenericRepositoryTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _context = new AppDbContext(dbOptions, true);

        _genericRepository = new GenericRepository<Shoe>(new AppDbContext(dbOptions, true));
    }

    [Fact]
    public async Task Get_Async()
    {
        var shoe = new List<Shoe>()
        {
            new Shoe()
            {
                Id = 1,
                UserId = 1,
                Brand = "Nike",
                Images = new List<string>() { "#", "#", "#", "#" },
                ThumbnailImage = "#",
                ShoeName = "Chron",
                ShoeSizes = new List<float>() { 3.5f, 15.2f, 20f },
                ShoeType = "Normal",
                CurrentPrice = 90f,
            },
            new Shoe()
            {
                Id = 2,
                UserId = 1,
                Brand = "Nike",
                Images = new List<string>() { "#", "#", "#", "#" },
                ThumbnailImage = "#",
                ShoeName = "Air Force 1",
                ShoeSizes = new List<float>() { 3.5f, 15.2f, 20f },
                ShoeType = "Normal",
                CurrentPrice = 90f,
            }
        };

        await _context.Shoes.AddRangeAsync(shoe);
        await _context.SaveChangesAsync();

        var allShoes = await _genericRepository.GetAsync();

        allShoes.ShouldBeOfType<List<Shoe>>();
        allShoes.Count().ShouldBeEquivalentTo(2);
        allShoes.ShouldNotBeNull();
    }
}