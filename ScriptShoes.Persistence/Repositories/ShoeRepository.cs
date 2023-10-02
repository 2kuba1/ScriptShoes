using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ShoeRepository : GenericRepository<Shoe>, IShoeRepository
{
    public ShoeRepository(AppDbContext context) : base(context)
    {
    }
}