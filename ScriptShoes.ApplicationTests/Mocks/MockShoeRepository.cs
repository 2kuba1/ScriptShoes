using Moq;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.ApplicationTests.Mocks;

public class MockShoeRepository
{
    public static Mock<IShoeRepository> GetAllShoes()
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

        var mockRepo = new Mock<IShoeRepository>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(shoe);
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(shoe[1]);
        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Shoe>()));
        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Shoe>()));
        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Shoe>()));
        mockRepo.Setup(r => r.GetByNameAsync("Nike")).ReturnsAsync(shoe[1]);

        return mockRepo;
    }
}