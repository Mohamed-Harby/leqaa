

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using Shared.Models.Services;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;


namespace payment.Controllers;
public class CheckoutController : Controller
    {
        private readonly HttpClient _httpClient;

        public CheckoutController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(UserPlan product)
        {
           
        _httpClient.Timeout=TimeSpan.FromMinutes(5);
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5196/checkout", content);

            if (!response.IsSuccessStatusCode)
            {
              return BadRequest(response);

            }

            var result = await response.Content.ReadAsStringAsync();

            var stripeSettings = JsonConvert.DeserializeObject<StripeSettings>(result);

            

           var sessionUrl = stripeSettings.Secret;

            return Redirect(sessionUrl);
        }


    public IActionResult success()
    {
        return View();
    }
    public IActionResult Faild()
    {
        return View();
    }
}

