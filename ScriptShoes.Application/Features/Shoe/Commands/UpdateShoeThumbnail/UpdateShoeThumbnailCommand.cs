using MediatR;

namespace ScriptShoes.Application.Features.Shoe.Commands.UpdateShoeThumbnail;

public record UpdateShoeThumbnailCommand(int Id, string Url) : IRequest<Unit>;