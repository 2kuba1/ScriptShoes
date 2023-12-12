using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeContent;

public class GetShoeContentQueryHandler : IRequestHandler<GetShoeContentQuery, GetShoeContentDto>
{
    private readonly IShoeRepository _shoeRepository;
    private readonly TypeAdapterConfig _typeAdapterConfig;

    public GetShoeContentQueryHandler(IShoeRepository shoeRepository, TypeAdapterConfig typeAdapterConfig)
    {
        _shoeRepository = shoeRepository;
        _typeAdapterConfig = GetTypeAdapterConfig();
    }

    public async Task<GetShoeContentDto> Handle(GetShoeContentQuery request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetShoeContent(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");
        
        var dto = shoe.Adapt<GetShoeContentDto>(_typeAdapterConfig);

        return dto;
    }

    private static TypeAdapterConfig GetTypeAdapterConfig()
    {
        TypeAdapterConfig config = new();
        config.NewConfig<Domain.Entities.Shoe, GetShoeContentDto>();
        return config;
    }
}