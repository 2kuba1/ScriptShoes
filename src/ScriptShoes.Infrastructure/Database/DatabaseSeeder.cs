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
                    "https://cdn.discordapp.com/attachments/1022135580399783959/1188472685605433384/pexels-ray-piedra-1456737.jpg?ex=659aa671&is=65883171&hm=8af97ed984d22e34f32ada706fe9ee30818b1b298b528df4ee3a6649956465fe&",
                CurrentPrice = 99.99f,
                UserId = 1,
                ShoeType = "Sport"
            },
            new Shoe()
            {
                Brand = "Adidas",
                ShoeName = "Forum Low",
                ThumbnailImage =
                    "https://cdn.discordapp.com/attachments/1022135580399783959/1188472686201016411/pexels-ray-piedra-1464625.jpg?ex=659aa671&is=65883171&hm=46e5ec82cf21db8e054aaf7d84514625ceb150c9b22a8dad2e9209319f4a5851&",
                CurrentPrice = 199.99f,
                UserId = 1,
                ShoeType = "Sport"
            }
        };


        await _dbContext.Shoes.AddRangeAsync(shoes);
        await _dbContext.SaveChangesAsync();
    }
}