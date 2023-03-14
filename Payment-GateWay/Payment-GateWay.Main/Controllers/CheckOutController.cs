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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Payment_Gateway.main.Controllers;

[ApiController]
[Route("[controller]")]

public class CheckoutController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private readonly static string s_wasmClientURL = "http://localhost:3000/";

    public CheckoutController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult> CheckoutPlan([FromBody] UserPlan product, [FromServices] IServiceProvider sp)
    {

        string? thisApiUrl = null;
        thisApiUrl = "http://localhost:5196";
        if (thisApiUrl is not null)
        {
            switch (product.PlanType.ToLower())
            {
                case "premium":
                    product.Price = 5000;
                    break;
                case "platinum":
                    product.Price = 8000;
                    break;
                default:
                    return BadRequest("Invalid plan type.");
            }
            string? user = GetUserNameFromToken(product.User);
            product.User = user;
            StripeSettings stripeSettings = await CheckOut(product, thisApiUrl);
            var pubKey = _configuration["Stripe:PubKey"];

            stripeSettings.PubKey = pubKey;
            stripeSettings.userName= user;

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
          
            SuccessUrl = $"{s_wasmClientURL}/success?sessionId=" + "{CHECKOUT_SESSION_ID}",
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
                            Description="for"+product.User,
                     
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






    [NonAction]

    private string GetUserNameFromToken(string token)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

        string userName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        return userName;
    }









}
