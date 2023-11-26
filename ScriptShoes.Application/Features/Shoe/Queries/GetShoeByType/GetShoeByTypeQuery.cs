using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetShoeByType;

public record GetShoeByTypeQuery(string ShoeType, int Count) : IRequest<List<GetShoeLimitedInformationDto>>;