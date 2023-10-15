using MediatR;

namespace ScriptShoes.Application.Features.User.Commands.UpdateProfilePicture;

public record UpdateProfilePictureCommand(string ImageUrl) : IRequest<Unit>;