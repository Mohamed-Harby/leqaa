using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Authentication.Infrastructure.NetworkCalls.EmailSender;
public class EmailSender : IEmailSender
{
    private readonly Smtp Smtp;

    public EmailSender(IOptions<Smtp> smtp)
    {
        Smtp = smtp.Value;
    }

    public async Task SendAsync(string toEmail, string subject, string body)
    {
        var mailMessage = new MimeMessage();
        mailMessage.From.Add(new MailboxAddress("leqaa.technical", Smtp.Email));
        mailMessage.To.Add(new MailboxAddress("", toEmail));
        mailMessage.Subject = subject;
        mailMessage.Body = new TextPart("plain")
        {
            Text = body
        };
        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.ConnectAsync(Smtp.Host, Smtp.Port, useSsl: true);
            await smtpClient.AuthenticateAsync(Smtp.Email, Smtp.Password);
            await smtpClient.SendAsync(mailMessage);
            await smtpClient.DisconnectAsync(quit: true);
        }
    }
}
