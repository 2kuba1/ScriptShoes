using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Infrastructure.Database;

public class DatabaseSeeder
{
    private readonly AppDbContext _dbContext;

    public DatabaseSeeder(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedData()
    {
        if (!await _dbContext.Database.CanConnectAsync()) return;
        if (_dbContext.Shoes.Any()) return;

        var shoes = new List<Shoe>()
        {
            new Shoe()
            {
                Brand = "Nike",
                ShoeName = "Chron",
                ThumbnailImage =
                    "https://cdn.discordapp.com/attachments/1022135580399783959/1173205642517946489/image_6.png?ex=659a7ae6&is=658805e6&hm=ae500e12ecb8da49dc39ebd7e5d47cf01843c1bef1b7deb6693d9c8d4d79815f&",
                CurrentPrice = 99.99f,
                UserId = 1,
                ShoeType = "Sport"
            },
            new Shoe()
            {
                Brand = "Adidas",
                ShoeName = "Forum Low",
                ThumbnailImage =
                    "https://cdn.discordapp.com/attachments/1022135580399783959/1188449224682115113/pol_pl_Buty-Adidas-FORUM-LOW-FY7757-Cloud-White-Cloud-White-Core-Black-9450_1.jpg?ex=659a9097&is=65881b97&hm=153f845b4baca871752d8d1713647cf5c5d385e8855fd3c0593bfb1ed4d096b4&",
                CurrentPrice = 199.99f,
                UserId = 1,
                ShoeType = "Sport"
            }
        };


        await _dbContext.Shoes.AddRangeAsync(shoes);
        await _dbContext.SaveChangesAsync();
    }
}