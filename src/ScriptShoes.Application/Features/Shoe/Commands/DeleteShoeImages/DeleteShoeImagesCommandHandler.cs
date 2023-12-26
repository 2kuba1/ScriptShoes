using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

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

        var images = shoe.Images;

        foreach (var imageIndex in request.ImageIndexes.Where(_ => shoe.Images is not null))
        {
            if (shoe.Images != null) shoe.Images[imageIndex] = "";
        }

        if (images is null)
            return Unit.Value;


        foreach (var image in images.ToList())
        {
            if (image == "")
                images.Remove(image);
        }

        shoe.Images = images;

        await _repository.UpdateAsync(shoe);

        return Unit.Value;
    }
}