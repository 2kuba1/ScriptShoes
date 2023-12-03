using System.Security.Cryptography;
using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.User.Commands.ResendVerificationEmail;

public class ResendVerificationEmailCommandHandler : IRequestHandler<ResendVerificationEmailCommand, Unit>
{
    private readonly IEmailCodesRepository _emailCodesRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailSenderService _emailSenderService;

    public ResendVerificationEmailCommandHandler(IEmailCodesRepository emailCodesRepository,
        IUserRepository userRepository, IEmailSenderService emailSenderService)
    {
        _emailCodesRepository = emailCodesRepository;
        _userRepository = userRepository;
        _emailSenderService = emailSenderService;
    }

    public async Task<Unit> Handle(ResendVerificationEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);

        if (user.IsVerified)
            throw new BadRequestException("User is already verified");

        var code = Convert.ToBase64String(RandomNumberGenerator.GetBytes(6));

        await _emailSenderService.SendEmail(user.Email,
            "ScriptShoes Verification",
            $"Verification code: {code}");

        var emailCode = await _emailCodesRepository.GetCodeByUserId(user.Id);

        if (emailCode is null)
            throw new NotFoundException("User doesn't have a verification code");

        emailCode.Code = code;

        await _emailCodesRepository.UpdateAsync(emailCode);

        return Unit.Value;
    }
}