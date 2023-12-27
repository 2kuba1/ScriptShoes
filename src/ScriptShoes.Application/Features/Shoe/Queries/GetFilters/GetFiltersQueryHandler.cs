using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetFilters;

public class GetFiltersQueryHandler : IRequestHandler<GetFilters.GetFiltersQuery, GetFiltersDto>
{
    private readonly IShoeRepository _shoeRepository;

    public GetFiltersQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<GetFiltersDto> Handle(GetFilters.GetFiltersQuery request, CancellationToken cancellationToken)
    {
        var shoes = await _shoeRepository.GetAsync() as List<Domain.Entities.Shoe>;

        if (shoes is null)
            throw new NotFoundException("Shoes not found");
        
        var sizesList = shoes.SelectMany(x => x.ShoeSizes!).ToList();
        
        var brands = new List<string>();
        var types = new List<string>();
        var sizes = new List<float>();

        foreach (var size in sizesList.Where(x => !sizes.Contains(x)))
        {
            sizes.Add(size);
        }
        
        foreach (var t in shoes)
        {
            if (!brands.Contains(t.Brand))
            {
                brands.Add(t.Brand);
            }
                
            if (!types.Contains(t.ShoeType))
            {
                types.Add(t.ShoeType);
            }
        }

        var results = new GetFiltersDto()
        {
            Sizes = sizes,
            Brand = brands,
            ShoeType = types
        };

        return results;
    }
}