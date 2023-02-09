namespace Authentication.Application.Interfaces;
public interface IEmailSender
{
    Task SendAsync(string toEmail, string subject, string body);
}