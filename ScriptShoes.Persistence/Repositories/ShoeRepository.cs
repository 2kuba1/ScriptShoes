using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Exceptions;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ShoeRepository : GenericRepository<Shoe>, IShoeRepository
{
    public ShoeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Shoe> GetByNameAsync(string shoeName)
    {
        var shoe = await _context.Shoes.FirstOrDefaultAsync(s => s.ShoeName == shoeName);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        return shoe;
    }
}