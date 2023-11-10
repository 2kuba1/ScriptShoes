using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IShoeRepository : IGenericRepository<Shoe>
{
    public Task<Shoe?> GetByNameAsync(string shoeName);
    public Task<PagedResult<GetShoeLimitedInformationDto>> GetPagedShoes(int pageNumber, int pageSize);
    public Task<PagedResult<SearchForShoesDto>> GetShoesBySearchPhrase(int pageSize, int pageNumber, string? searchPhrase);
    public Task<GetShoeContentDto?> GetShoeContent(int shoeId);
}