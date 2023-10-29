using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.User.Queries.GetExpiredCodes;

public class GetExpiredCodesQueryHandler : IRequestHandler<GetExpiredCodesQuery, List<EmailCode>>
{
    private readonly IEmailCodesRepository _emailCodesRepository;

    public GetExpiredCodesQueryHandler(IEmailCodesRepository emailCodesRepository)
    {
        _emailCodesRepository = emailCodesRepository;
    }
    
    public async Task<List<EmailCode>> Handle(GetExpiredCodesQuery request, CancellationToken cancellationToken)
    {
        var expiredCodes = _emailCodesRepository.GetExpiredCodes();
        return expiredCodes as List<EmailCode> ?? new List<EmailCode>();
    }
}