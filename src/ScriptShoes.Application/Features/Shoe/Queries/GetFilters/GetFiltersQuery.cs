using MediatR;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.Application.Features.Shoe.Queries.GetFilters;

public record GetFiltersQuery : IRequest<GetFiltersDto>;