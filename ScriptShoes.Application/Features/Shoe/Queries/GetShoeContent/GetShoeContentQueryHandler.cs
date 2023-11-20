using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Shoe;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeContent;

public class GetShoeContentQueryHandler : IRequestHandler<GetShoeContentQuery, GetShoeContentDto>
{
    private readonly IShoeRepository _shoeRepository;

    public GetShoeContentQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }

    public async Task<GetShoeContentDto> Handle(GetShoeContentQuery request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetShoeContent(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        TypeAdapterConfig config = new();

        config.NewConfig<Domain.Entities.Shoe, GetShoeContentDto>();

        var dto = shoe.Adapt<GetShoeContentDto>(config);

        return dto;
    }
}