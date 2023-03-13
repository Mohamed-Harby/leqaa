using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;

using Stripe.Checkout;
using Stripe;
using Shared.Models;
using Shared.Models.Services;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Payment_Gateway.main.Controllers;

[ApiController]
[Route("[controller]")]
/*[ApiExplorerSettings(IgnoreApi = true)]*/
public class CheckoutController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private readonly static string s_wasmClientURL = "https://localhost:7132";

    public CheckoutController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult> CheckoutPlan([FromBody] UserPlan product, [FromServices] IServiceProvider sp)
    {
        /*var referer = Request.Headers.Referer;
        s_wasmClientURL = referer[0];

        // Build the URL to which the customer will be redirected after paying.
        var server = sp.GetRequiredService<IServer>();

        var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

        string? thisApiUrl = null;

        if (serverAddressesFeature is not null)
        {
            thisApiUrl = "http://localhost:5196";
            Console.WriteLine(thisApiUrl);
        }*/
        string? thisApiUrl = null;
        thisApiUrl = "http://localhost:5196";
        if (thisApiUrl is not null)
        {
            StripeSettings stripeSettings = await CheckOut(product, thisApiUrl);
            var pubKey = _configuration["Stripe:PubKey"];

            stripeSettings.PubKey = pubKey;

            return Ok(stripeSettings);
        }
        else
        {
            return StatusCode(500);
        }
    }

    [NonAction]
    public async Task<StripeSettings> CheckOut(UserPlan product, string thisApiUrl)
    {
      
        var options = new SessionCreateOptions
        {
          
            SuccessUrl = $"{s_wasmClientURL}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}",
            CancelUrl = s_wasmClientURL + "/failed",  
            PaymentMethodTypes = new List<string> 
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = product.Price, 
                        Currency = "USD",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.PlanType,
                     
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment" 
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);
       var f=new StripeSettings();
        f.SessionId = session.Id;
        f.Secret = session.Url;
        return f;
    }











/*
    [NonAction]
    public void SendOrderConfirmationEmail(string toEmailAddress, UserPlan order)
    {
        MailMessage mail = new MailMessage();
        MailMessage.From.Add(new MailboxAddress("leqaa.technical", Smtp.Email));
        mail.To.Add(new MailAddress(toEmailAddress));
        mail.Subject = "Order Confirmation";
        mail.Body = "Dear <br><br>Your order has been confirmed.<br><br>Order details:<br><br>" ;
        mail.IsBodyHtml = true;

        SmtpClient client = new SmtpClient("smtp.example.com", 587);
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("username", "password");

        client.Send(mail);
    }*/

   /* public string GetOrderDetails(Order order)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        sb.Append("<tr><td>Product Name</td><td>Price</td><td>Quantity</td><td>Total</td></tr>");
        foreach (var item in order.Items)
        {
            sb.Append("<tr><td>" + item.ProductName + "</td><td>" + item.Price + "</td><td>" + item.Quantity + "</td><td>" + (item.Price * item.Quantity) + "</td></tr>");
        }
        sb.Append("<tr><td colspan='3'>Total</td><td>" + order.TotalAmount + "</td></tr>");
        sb.Append("</table>");
        return sb.ToString();
    }*/











}
