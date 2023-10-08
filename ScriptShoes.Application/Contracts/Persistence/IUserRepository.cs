using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> IsUserNameEqual(string name);
    public Task<bool> IsEmailEqual(string email);
}