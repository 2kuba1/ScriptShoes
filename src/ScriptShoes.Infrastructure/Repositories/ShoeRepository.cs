using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task<List<Shoe>> GetPagedShoes(int pageNumber, int pageSize)
    {
        var baseQuery = _context.Shoes.OrderByDescending(x => x.Id);

        var shoes = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return shoes;
    }

    public async Task<List<Shoe>> GetShoesBySearchPhrase(int pageSize, int pageNumber,
        string? searchPhrase)
    {
        var baseQuery = _context.Shoes.Where(r =>
            searchPhrase == null || (r.Brand.ToLower() + " " + r.ShoeName.ToLower()).Contains(searchPhrase.ToLower()) ||
            (r.ShoeName.ToLower() + " " + r.Brand.ToLower()).Contains(searchPhrase.ToLower()) ||
            r.Brand.ToLower().Contains(searchPhrase.ToLower()) ||
            r.ShoeName.ToLower().Contains(searchPhrase.ToLower()));

        var shoes = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return shoes;
    }

    public async Task<Shoe?> GetShoeContent(int shoeId)
    {
        var shoe = await _context.Shoes.FirstOrDefaultAsync(x => x.Id == shoeId);
        return shoe;
    }

    public async Task<List<Shoe>> GetShoeByType(string shoeType, int count)
    {
        var shoes = await _context.Shoes
            .Where(x => x.ShoeType.ToLower() == shoeType.ToLower()).Take(count)
            .ToListAsync();
        return shoes;
    }
}