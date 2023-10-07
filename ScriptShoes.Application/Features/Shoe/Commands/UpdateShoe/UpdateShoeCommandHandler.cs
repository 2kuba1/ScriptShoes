using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;

public class UpdateShoeCommandHandler : IRequestHandler<UpdateShoeCommand, Unit>
{
    private readonly IShoeRepository _repository;

    public UpdateShoeCommandHandler(IShoeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateShoeCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _repository.GetByIdAsync(request.Id);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        if (request.Dto.ShoeType is not null)
            shoe.ShoeType = request.Dto.ShoeType;

        if (request.Dto.Brand is not null)
            shoe.Brand = request.Dto.Brand;

        if (request.Dto.CurrentPrice is not null)
            shoe.CurrentPrice = (float)request.Dto.CurrentPrice;

        if (request.Dto.NewName is not null)
            shoe.ShoeName = request.Dto.NewName;

        if (request.Dto.SizesList is not null)
            shoe.ShoeSizes = request.Dto.SizesList;

        if (request.Dto.Images is not null)
            shoe.Images?.AddRange(request.Dto.Images);

        if (request.Dto.ThumbnailImage is not null)
            shoe.ThumbnailImage = request.Dto.ThumbnailImage;

        await _repository.UpdateAsync(shoe);

        return Unit.Value;
    }
}