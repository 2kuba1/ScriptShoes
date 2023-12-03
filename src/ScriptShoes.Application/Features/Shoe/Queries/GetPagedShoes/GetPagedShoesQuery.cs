using MediatR;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetPagedShoes;

public record GetPagedShoesQuery(int PageNumber, int PageSize) : IRequest<PagedResult<GetShoeLimitedInformationDto>>;