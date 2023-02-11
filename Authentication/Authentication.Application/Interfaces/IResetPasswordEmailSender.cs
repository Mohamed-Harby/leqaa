namespace Authentication.Application.Interfaces;
public interface IResetPasswordEmailSender
{
    Task SendPasswordResetAsync(string toEmail, string changePasswordLink, string token);
}