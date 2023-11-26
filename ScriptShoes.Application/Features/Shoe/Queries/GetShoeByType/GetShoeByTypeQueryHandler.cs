using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeByType;

public class GetShoeByTypeQueryHandler : IRequestHandler<GetShoeByTypeQuery, List<GetShoeLimitedInformationDto>>
{
    private readonly IShoeRepository _shoeRepository;

    public GetShoeByTypeQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<List<GetShoeLimitedInformationDto>> Handle(GetShoeByTypeQuery request, CancellationToken cancellationToken)
    {
        var shoes = await _shoeRepository.GetShoeByType(request.ShoeType, request.Count);

        var dto = shoes.Adapt<List<GetShoeLimitedInformationDto>>();
        return dto;
    }
}