using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;

public class GetAllShoesQueryHandler : IRequestHandler<GetAllShoesQuery, List<GetShoeDto>>
{
    private readonly IShoeRepository _repository;

    public GetAllShoesQueryHandler(IShoeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetShoeDto>> Handle(GetAllShoesQuery request, CancellationToken cancellationToken)
    {
        var shoes = await _repository.GetAsync();

        var dto = shoes.Adapt<List<GetShoeDto>>();

        return dto;
    }
}