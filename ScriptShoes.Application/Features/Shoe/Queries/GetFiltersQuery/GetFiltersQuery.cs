using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetFiltersQuery;

public record GetFiltersQuery : IRequest<GetFiltersDto>;