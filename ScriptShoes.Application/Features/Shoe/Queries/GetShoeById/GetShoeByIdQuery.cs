using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeById;

public record GetShoeByIdQuery(int Id) : IRequest<GetShoeDto>;