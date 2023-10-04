using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Shoe;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeById;

public class GetShoeByIdQueryHandler : IRequestHandler<GetShoeByIdQuery, GetShoeDto>
{
    private readonly IShoeRepository _shoeRepository;

    public GetShoeByIdQueryHandler(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }
    
    public async Task<GetShoeDto> Handle(GetShoeByIdQuery request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.Id);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var dto = shoe.Adapt<GetShoeDto>();
        return dto;
    }
}