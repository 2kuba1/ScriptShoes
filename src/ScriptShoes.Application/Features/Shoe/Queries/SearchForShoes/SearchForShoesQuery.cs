using MediatR;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.SearchForShoes;

public record SearchForShoesQuery(int PageSize, int PageNumber, string SearchPhrase) : IRequest<PagedResult<SearchForShoesDto>>;