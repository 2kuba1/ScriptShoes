namespace ScriptShoes.Application.Contracts.Services;

public interface IEmailSenderService
{
    Task SendEmail(string mailTo, string emailSubject, string emailBody);
}