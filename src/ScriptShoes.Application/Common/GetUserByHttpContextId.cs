using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Common;

public static class GetUserByHttpContextId
{
    internal static async Task<User> Get(IUserRepository userRepository)
    {
        if (userRepository.GetUserId is null)
            throw new NotFoundException("User not found");

        var user = await userRepository.GetByIdAsync(userRepository.GetUserId.Value);

        if (user is null)
            throw new NotFoundException("User not found");

        return user;
    }
}