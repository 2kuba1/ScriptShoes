using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetPagedShoes;

public class GetPagedShoesQueryHandler : IRequestHandler<GetPagedShoesQuery, PagedResult<GetShoeLimitedInformationDto>>
{
    private readonly IShoeRepository _shoeRepository;

    public GetPagedShoesQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<PagedResult<GetShoeLimitedInformationDto>> Handle(GetPagedShoesQuery request, CancellationToken cancellationToken)
    {
        var pagedResults = _shoeRepository.GetPagedShoes(request.PageNumber, request.PageSize);
        return pagedResults;
    }
}