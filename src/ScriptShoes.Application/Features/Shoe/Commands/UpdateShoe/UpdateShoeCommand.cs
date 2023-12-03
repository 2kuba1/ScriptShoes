using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;

public record UpdateShoeCommand(int Id, UpdateShoeDto Dto) : IRequest<Unit>;