using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.AddProfilePicture;

public record UpdateProfilePictureCommand(string ImageUrl) : IRequest<Unit>;