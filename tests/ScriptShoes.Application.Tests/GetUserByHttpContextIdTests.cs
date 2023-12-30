using FluentAssertions;
using Moq;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Tests;

public class GetUserByHttpContextIdTests
{
    [Fact]
    public async Task Get_ForAuthenticatedUserId_ReturnsUser()
    {
        //arrange

        var user = new User()
        {
            Id = 1,
            Username = "Test",
        };

        var userRepository = new Mock<IUserRepository>();

        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync(user);

        //act

        var getUserByHttpContextId = await GetUserByHttpContextId.Get(userRepository.Object);

        //assert

        getUserByHttpContextId.Should().Be(user);
    }

    [Fact]
    public async Task Get_ForNullGetUserId_ThrowsNotFoundException()
    {
        //arrange

        var userRepository = new Mock<IUserRepository>();

        userRepository.Setup(u => u.GetUserId).Returns((int?)null);

        //act

        Func<Task> action = async () => await GetUserByHttpContextId.Get(userRepository.Object);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Get_ForNullUserObject_ThrowsNotFoundException()
    {
        //arrange

        var userRepository = new Mock<IUserRepository>();

        userRepository.Setup(u => u.GetUserId).Returns(1);
        userRepository.Setup(u => u.GetByIdAsync(1)).ReturnsAsync((User)null);

        //act

        Func<Task> action = async () => await GetUserByHttpContextId.Get(userRepository.Object);

        //assert

        await action.Should().ThrowAsync<NotFoundException>();
    }
}