using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Commands.AddShoeThumbnail;

public class UpdateShoeThumbnailCommandHandler : IRequestHandler<UpdateShoeThumbnailCommand, Unit>
{
    private readonly IShoeRepository _repository;

    public UpdateShoeThumbnailCommandHandler(IShoeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateShoeThumbnailCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _repository.GetByIdAsync(request.Id);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        shoe.ThumbnailImage = request.Url;

        await _repository.UpdateAsync(shoe);

        return Unit.Value;
    }
}