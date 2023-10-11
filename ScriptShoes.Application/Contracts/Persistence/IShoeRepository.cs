using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IShoeRepository : IGenericRepository<Shoe>
{
    public Task<Shoe?> GetByNameAsync(string shoeName);
}