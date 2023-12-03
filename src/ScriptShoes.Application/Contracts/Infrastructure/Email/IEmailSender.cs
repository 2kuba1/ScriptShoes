namespace ScriptShoes.Application.Contracts.Infrastructure.Email;

public interface IEmailSender
{
    Task SendEmail(string mailTo, string emailSubject, string emailBody);
}