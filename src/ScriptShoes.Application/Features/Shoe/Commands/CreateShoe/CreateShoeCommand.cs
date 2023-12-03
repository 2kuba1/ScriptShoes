using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;

public record CreateShoeCommand(CreateShoeDto Dto) : IRequest<int>;