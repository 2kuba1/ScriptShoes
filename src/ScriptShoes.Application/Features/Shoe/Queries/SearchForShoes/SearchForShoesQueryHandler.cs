using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.SearchForShoes;

public class SearchForShoesQueryHandler : IRequestHandler<SearchForShoesQuery, PagedResult<SearchForShoesDto>>
{
    private readonly IShoeRepository _shoeRepository;

    public SearchForShoesQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }

    public async Task<PagedResult<SearchForShoesDto>> Handle(SearchForShoesQuery request,
        CancellationToken cancellationToken)
    {
        var shoes = await _shoeRepository.GetShoesBySearchPhrase(request.PageSize, request.PageNumber, request.SearchPhrase);
        var totalItemsCount = shoes.Count;

        var mappedValues = shoes.Adapt<List<SearchForShoesDto>>();

        return new PagedResult<SearchForShoesDto>(mappedValues, totalItemsCount, request.PageSize, request.PageNumber);
    }
}