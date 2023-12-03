using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using ScriptShoes.Application.Contracts.Infrastructure.Email;

namespace ScriptShoes.Infrastructure.EmailSender;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public async Task SendEmail(string mailTo, string emailSubject, string emailBody)
    {
        try
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration.GetValue<string>("Email:EmailAddress")));
            email.To.Add(MailboxAddress.Parse(mailTo));
            email.Subject = emailSubject;
            email.Body = new TextPart(TextFormat.Plain) { Text = emailBody };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_configuration.GetValue<string>("Email:EmailAddress"),
                _configuration.GetValue<string>("Email:Password"));
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            throw new Exception("Something went wrong");
        }
    }
}