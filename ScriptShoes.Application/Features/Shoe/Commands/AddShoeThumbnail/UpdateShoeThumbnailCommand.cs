using MediatR;

namespace ScriptShoes.Application.Features.Shoe.Commands.AddShoeThumbnail;

public record UpdateShoeThumbnailCommand(int Id, string Url) : IRequest<Unit>;