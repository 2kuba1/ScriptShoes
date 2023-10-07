using MediatR;

namespace ScriptShoes.Application.Features.Shoe.Commands.DeleteShoeImages;

public record DeleteShoeImagesCommand(int Id, List<int> ImageIndexes) : IRequest<Unit>;