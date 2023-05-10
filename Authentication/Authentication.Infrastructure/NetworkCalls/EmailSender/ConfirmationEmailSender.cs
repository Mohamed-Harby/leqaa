using System.Web;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Authentication.Infrastructure.NetworkCalls.EmailSender;
public class ConfirmationEmailSender : BaseEmailSender, IConfirmationEmailSender
{
    public ConfirmationEmailSender(IOptions<Smtp> smtp, IConfiguration configuration) : base(smtp, configuration)
    {
    }
    
    
}