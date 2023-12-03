using MediatR;

namespace ScriptShoes.Application.Features.Shoe.Commands.DeleteShoe;

public record DeleteShoeCommand(int Id) : IRequest<Unit>;