using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetShoeRates;

public record GetShoeRatesQuery(int ShoeId) : IRequest<GetShoeRatesDto>;