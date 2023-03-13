using Newtonsoft.Json;
using Shared.Models;
using Shared.Models.Services;
using System.Text;

namespace payment.Models;
public class StripeApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl="http://localhost:5196";

    public StripeApiClient(string baseUrl)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl;
    }

    public async Task<string> CheckoutOrder(UserPlan product)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/Checkout/Order");

        request.Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var stripeSettings = JsonConvert.DeserializeObject<StripeSettings>(responseContent);
            return stripeSettings.SessionId;
        }
        else
        {
            throw new Exception($"Error calling CheckoutOrder API: {response.ReasonPhrase}");
        }
    }
}
