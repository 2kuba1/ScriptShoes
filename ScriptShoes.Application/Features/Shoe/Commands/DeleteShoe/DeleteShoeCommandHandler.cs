using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Commands.DeleteShoe;

public class DeleteShoeCommandHandler : IRequestHandler<DeleteShoeCommand, Unit>
{
    private readonly IShoeRepository _repository;

    public DeleteShoeCommandHandler(IShoeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteShoeCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _repository.GetByIdAsync(request.Id);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        await _repository.DeleteAsync(shoe);

        return Unit.Value;
    }
}