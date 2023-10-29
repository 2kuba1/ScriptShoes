using MediatR;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.User.Queries.GetExpiredCodes;

public record GetExpiredCodesQuery() : IRequest<List<EmailCode>>;