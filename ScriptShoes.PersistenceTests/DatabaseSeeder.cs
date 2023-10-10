using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.PersistenceTests;

public static class DatabaseSeeder
{
    public static void SeedDatabase(AppDbContext context)
    {
        if (!context.Shoes.Any())
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

            context.Shoes.AddRange(shoe);
            context.SaveChanges();
        }
    }
}