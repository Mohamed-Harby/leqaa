using System.Web;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Authentication.Infrastructure.NetworkCalls.EmailSender;
public class ResetPasswordEmailSender : BaseEmailSender, IResetPasswordEmailSender
{
    public ResetPasswordEmailSender(IOptions<Smtp> smtp, IConfiguration configuration) : base(smtp, configuration)
    {
    }
}
