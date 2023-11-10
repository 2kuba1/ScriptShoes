using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeContent;

public record GetShoeContentQuery(int ShoeId) : IRequest<GetShoeContentDto>;