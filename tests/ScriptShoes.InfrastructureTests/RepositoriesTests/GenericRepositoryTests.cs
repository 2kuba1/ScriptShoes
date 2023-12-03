using Microsoft.EntityFrameworkCore;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;
using ScriptShoes.Infrastructure.Repositories;
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

        DatabaseSeeder.SeedDatabase(_context);

        _genericRepository = new GenericRepository<Shoe>(new AppDbContext(dbOptions, true));
    }

    [Fact]
    public async Task Get_Async()
    {
        var allShoes = await _genericRepository.GetAsync();

        allShoes.ShouldBeOfType<List<Shoe>>();
        allShoes.Count().ShouldBeEquivalentTo(2);
        allShoes.ShouldNotBeNull();
    }

    [Fact]
    public async Task Get_By_Id()
    {
        var shoe = await _genericRepository.GetByIdAsync(1);

        shoe.ShouldNotBeNull();
        shoe.ShouldBeOfType<Shoe>();
    }

    [Fact]
    public async Task Create()
    {
        var shoe = new Shoe()
        {
            Id = 3,
            UserId = 1,
            Brand = "Nike",
            Images = new List<string>() { "#", "#", "#", "#" },
            ThumbnailImage = "#",
            ShoeName = "Chron",
            ShoeSizes = new List<float>() { 3.5f, 15.2f, 20f },
            ShoeType = "Normal",
            CurrentPrice = 90f,
        };

        await _genericRepository.CreateAsync(shoe);

        _context.Shoes.Count().ShouldBeEquivalentTo(3);
    }

    [Fact]
    public async Task Delete()
    {
        var shoe = new Shoe()
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
        };

        await _genericRepository.DeleteAsync(shoe);

        _context.Shoes.Count().ShouldBeEquivalentTo(1);
    }

    [Fact]
    public async Task Update()
    {
        var shoe = _context.Shoes.FirstOrDefault(x => x.Id == 1);

        shoe!.ShoeName = "Jordan 1";
        shoe.ShoeType = "Sport";
        shoe.ShoeSizes = new List<float>() { 10.3f, 20.9f, 3 };
        shoe.CurrentPrice = 30f;
        shoe.Brand = "Nike Jordan";
        shoe.Images = new List<string>() { "##", "##" };
        shoe.ThumbnailImage = "##";

        await _genericRepository.UpdateAsync(shoe!);


        var shoeAfterUpdate = await _context.Shoes.FirstOrDefaultAsync(x => x.Id == 1);

        shoeAfterUpdate?.ShoeName.ShouldBeEquivalentTo("Jordan 1");
        shoeAfterUpdate?.ShoeType.ShouldBeEquivalentTo("Sport");
        shoeAfterUpdate?.ShoeSizes.ShouldBeEquivalentTo(new List<float>() { 10.3f, 20.9f, 3 });
        shoeAfterUpdate?.CurrentPrice.ShouldBeEquivalentTo(30f);
        shoeAfterUpdate?.Brand.ShouldBeEquivalentTo("Nike Jordan");
        shoeAfterUpdate?.Images.ShouldBeEquivalentTo(new List<string>() { "##", "##" });
        shoeAfterUpdate?.ThumbnailImage.ShouldBeEquivalentTo("##");
    }

    private void SeedDatabase()
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

        _context.Shoes.AddRange(shoe);
        _context.SaveChanges();
    }
}