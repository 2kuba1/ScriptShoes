using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;

public record GetAllShoesQuery() : IRequest<List<GetShoeDto>>;