using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetFiltersQuery;

public class GetFiltersQueryHandler : IRequestHandler<GetFiltersQuery, GetFiltersDto>
{
    private readonly IShoeRepository _shoeRepository;

    public GetFiltersQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<GetFiltersDto> Handle(GetFiltersQuery request, CancellationToken cancellationToken)
    {
        var filters = await _shoeRepository.GetAsync();
        
        var sizesList = filters.SelectMany(x => x.ShoeSizes!).ToList();
        
        var brands = new List<string>();
        var types = new List<string>();
        var sizes = new List<float>();

        foreach (var size in sizesList.Where(x => !sizes.Contains(x)))
        {
            sizes.Add(size);
        }
        
        foreach (var t in filters)
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