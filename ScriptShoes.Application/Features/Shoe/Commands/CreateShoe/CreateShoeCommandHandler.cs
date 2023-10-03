using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;

public class CreateShoeCommandHandler : IRequestHandler<CreateShoeCommand, int>
{
    private readonly IShoeRepository _repository;

    public CreateShoeCommandHandler(IShoeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<int> Handle(CreateShoeCommand request, CancellationToken cancellationToken)
    {
        var shoe = request.Dto.Adapt<Domain.Shoe>();
        
        shoe.UserId = 1;
        
        await _repository.CreateAsync(shoe);

        return shoe.Id;
    }
}