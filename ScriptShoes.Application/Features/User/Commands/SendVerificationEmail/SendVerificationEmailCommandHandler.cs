﻿using System.Security.Cryptography;
using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Infrastructure.Email;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.User.Commands.SendVerificationEmail;

public class SendVerificationEmailCommandHandler : IRequestHandler<SendVerificationEmailCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;
    private readonly IEmailCodesRepository _emailCodesRepository;

    public SendVerificationEmailCommandHandler(IUserRepository userRepository, IEmailSender emailSender,
        IEmailCodesRepository emailCodesRepository)
    {
        _userRepository = userRepository;
        _emailSender = emailSender;
        _emailCodesRepository = emailCodesRepository;
    }


    public async Task<Unit> Handle(SendVerificationEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);

        if (user.IsVerified)
            throw new BadRequestException("User is already verified");

        if (await _emailCodesRepository.DoesUserHaveACode(user.Id))
            throw new BadRequestException("This user already has an active verification code");

        var code = Convert.ToBase64String(RandomNumberGenerator.GetBytes(6));

        await _emailSender.SendEmail(user.Email,
            "ScriptShoes Verification",
            $"Verification code: {code}");

        var emailCode = new EmailCode()
        {
            Code = code,
            Expires = DateTime.UtcNow.AddMinutes(30),
            UserId = _userRepository.GetUserId!.Value
        };

        await _emailCodesRepository.CreateAsync(emailCode);

        return Unit.Value;
    }
}