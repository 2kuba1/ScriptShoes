using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Commands.DeleteShoeImages;

public class DeleteShoeImagesCommandHandler : IRequestHandler<DeleteShoeImagesCommand, Unit>
{
    private readonly IShoeRepository _repository;

    public DeleteShoeImagesCommandHandler(IShoeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteShoeImagesCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _repository.GetByIdAsync(request.Id);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        foreach (var imageIndex in request.ImageIndexes)
        {
            shoe.Images?.Remove(shoe.Images[imageIndex]);
        }

        await _repository.UpdateAsync(shoe);

        return Unit.Value;
    }
}