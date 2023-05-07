using System.Net.Http.Headers;
using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models;
using Newtonsoft.Json;

namespace BusinessLogic.Infrastructure.NetworkCalls.Helpers;
public class APIHelper : IAPIHelper
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpHelper _httpHelper;

    public APIHelper(IHttpClientFactory httpClientFactory, HttpHelper httpHelper)
    {
        _httpClientFactory = httpClientFactory;
        _httpHelper = httpHelper;
    }

    public async Task<TRes> SendAsync<TRes>(APIRequestModel requestModel)
    {
        var http = _httpClientFactory.CreateClient(requestModel.APIName);
        var token = _httpHelper.GetJwtToken();
        if (!String.IsNullOrEmpty(token))
        {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var httpRequestMessage = new HttpRequestMessage(requestModel.HttpMethod, requestModel.Url);
        if (requestModel.RequestContent is not null)
        {
            var body = JsonConvert.SerializeObject(requestModel.RequestContent);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = content;
        }
        var response = await http.SendAsync(httpRequestMessage);
        return JsonConvert.DeserializeObject<TRes>(await response.Content.ReadAsStringAsync())!;
    }
}