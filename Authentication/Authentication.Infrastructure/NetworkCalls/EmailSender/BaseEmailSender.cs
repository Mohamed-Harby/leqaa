using System.Web;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Authentication.Infrastructure.NetworkCalls.EmailSender;
public abstract class BaseEmailSender : IEmailSender, IConfirmationEmailSender, IResetPasswordEmailSender
{
    protected readonly Smtp Smtp;
    private readonly IConfiguration _configuration;
    public BaseEmailSender(IOptions<Smtp> smtp, IConfiguration configuration)
    {
        Smtp = smtp.Value;
        _configuration = configuration;
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
            await smtpClient.ConnectAsync(Smtp.Host, Smtp.Port, useSsl: false);
            await smtpClient.AuthenticateAsync(Smtp.Email, Smtp.Password);
            await smtpClient.SendAsync(mailMessage);
            await smtpClient.DisconnectAsync(quit: true);
        }
    }
    public async Task SendConfirmationAsync(string toEmail, string confirmationLink, string token)
    {
        var encodedToken = HttpUtility.UrlEncode(token);
        var encodedEmail = HttpUtility.UrlEncode(toEmail);
        var messageBody =
            _configuration.GetSection("Uri").Value +
            confirmationLink + '?' + "email=" + encodedEmail +
             '&' + "token=" + encodedToken;

        await this.SendAsync(toEmail, "Email confirmation link", messageBody);
    }
    public async Task SendPasswordResetAsync(string toEmail, string token)
    {
        await this.SendAsync(toEmail, "Password reset token", token);
    }
}
