namespace Authentication.Application.Interfaces;
public interface IConfirmationEmailSender
{
    Task SendConfirmationAsync(string toEmail, string confirmationLink, string token);
}