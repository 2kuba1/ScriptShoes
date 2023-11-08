using Mapster;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ShoeRepository : GenericRepository<Shoe>, IShoeRepository
{
    public ShoeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Shoe?> GetByNameAsync(string shoeName)
    {
        var shoe = await _context.Shoes.FirstOrDefaultAsync(s => s.ShoeName == shoeName);

        return shoe;
    }

    public async Task<PagedResult<GetShoeLimitedInformationDto>> GetPagedShoes(int pageNumber, int pageSize)
    {
        var baseQuery = _context.Shoes.OrderByDescending(x => x.Id);

        var shoes = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        var totalItemsCount = shoes.Count;

        var mappedValues = shoes.Adapt<List<GetShoeLimitedInformationDto>>();

        var pagedShoes =
            new PagedResult<GetShoeLimitedInformationDto>(mappedValues, totalItemsCount, pageSize, pageNumber);
        return pagedShoes;
    }

    public async Task<PagedResult<SearchForShoesDto>> GetShoesBySearchPhrase(int pageSize, int pageNumber,
        string? searchPhrase)
    {
        var baseQuery = _context.Shoes.Where(r =>
            searchPhrase == null || (r.ShoeName.ToLower().Contains(searchPhrase.ToLower())));

        var shoes = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        var totalItemsCount = baseQuery.Count();

        var mappedValues = shoes.Adapt<List<SearchForShoesDto>>();

        return new PagedResult<SearchForShoesDto>(mappedValues, totalItemsCount, pageSize, pageNumber);
    }
}