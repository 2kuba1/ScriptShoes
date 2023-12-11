using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

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

        if (!context.Users.Any())
        {
            var users = new List<User>()
            {
                new User()
                {
                    Email = "kuba@gmail.com",
                    RoleId = 1,
                    FirstName = "Jakub",
                    LastName = "Wojtyna",
                    Username = "2kuba1",
                    ProfilePictureUrl = "#"
                },
                new User()
                {
                    Email = "kub2a@gmail.com",
                    RoleId = 2,
                    FirstName = "Kuba",
                    LastName = "Fojtyna",
                    Username = "3kuba4",
                    ProfilePictureUrl = "##"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}