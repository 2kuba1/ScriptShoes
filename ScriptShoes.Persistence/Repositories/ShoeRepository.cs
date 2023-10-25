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

    public PagedResult<GetShoeLimitedInformationDto> GetPagedShoes(int pageNumber, int pageSize)
    {
        var baseQuery = _context.Shoes.OrderByDescending(x => x.Id);

        var shoes = baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

        var totalItemsCount = shoes.Count;

        var mappedValues = shoes.Adapt<List<GetShoeLimitedInformationDto>>();

        var pagedShoes =
            new PagedResult<GetShoeLimitedInformationDto>(mappedValues, totalItemsCount, pageSize, pageNumber);
        return pagedShoes;
    }
}