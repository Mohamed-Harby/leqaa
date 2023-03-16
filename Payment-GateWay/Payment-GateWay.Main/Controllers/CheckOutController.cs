using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
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
using Microsoft.EntityFrameworkCore;
using Payment_GateWay.Main.Data;
using Payment_Gateway.main.Data.Repository;

namespace Payment_Gateway.main.Controllers;

[ApiController]
[Route("[controller]")]

public class CheckoutController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserPlanRepository _userPlanRepository;


    private readonly static string s_wasmClientURL = "http://localhost:3000/";

    public CheckoutController(IConfiguration configuration, IUserPlanRepository userPlanRepository)
    {
        _configuration = configuration;
        _userPlanRepository = userPlanRepository;

    }

    [HttpPost]
    public async Task<ActionResult> CheckoutPlan([FromBody] UserPlan product, [FromServices] IServiceProvider sp)
    {
        if (product.User=="" ||product.User=="string")
        {
            string error = "not valid token";
            return BadRequest(error);
        }

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
            string? user = GetUserNameFromToken(product.User!);
            product.User = user;
            StripeSettings stripeSettings = await CheckOut(product, thisApiUrl);
            var pubKey = _configuration["Stripe:PubKey"];

            stripeSettings.PubKey = pubKey;
            stripeSettings.userName = user;


            //here you save in data base
            if (user != null)
            {
             await   _userPlanRepository.AddAsync(product);
              await  _userPlanRepository.SaveAsync();


            }

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
                        UnitAmount = product.Price*100,
                        Currency = "USD",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.PlanType,
                            Description="User Name"+product.User,

                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment"
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);
        var f = new StripeSettings();
        f.SessionId = session.Id;
        f.Secret = session.Url;
        return f;
    }






    [NonAction]

    private string GetUserNameFromToken(string token)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

        string? userName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        if (userName==null)
        {
            return "invalid token,please try again";
        }
        return userName;
    }


    [HttpGet("GetPlanType")]
    public async Task<string> GetPlanType(string token)
    {
        string? userName = GetUserNameFromToken(token!);
        if (userName==null)
        {
            return "not valid token";
        }
        var userPlan = await _userPlanRepository.GetAsync(userName);
        return userPlan;

    }



}