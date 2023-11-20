using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IShoeRepository : IGenericRepository<Shoe>
{
    public Task<Shoe?> GetByNameAsync(string shoeName);
    public Task<List<Shoe>> GetPagedShoes(int pageNumber, int pageSize);

    public Task<List<Shoe>> GetShoesBySearchPhrase(int pageSize, int pageNumber, string? searchPhrase);
    public Task<Shoe?> GetShoeContent(int shoeId);
}