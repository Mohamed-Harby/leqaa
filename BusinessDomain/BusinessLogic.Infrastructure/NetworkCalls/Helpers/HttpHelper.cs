using System.Text;
using BusinessLogic.Application.Interfaces;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BusinessLogic.Infrastructure.NetworkCalls.Helpers;
public class HttpHelper : IHttpHelper
{
    private readonly IHttpContextAccessor HttpAccessor;
    public HttpContext HttpContext;
    public HttpRequest Request;
    public HttpResponse Response;
    public HttpHelper(IHttpContextAccessor httpAccessor)
    {
        HttpAccessor = httpAccessor;
        Request = HttpAccessor.HttpContext.Request;
        Response = HttpAccessor.HttpContext.Response;
        HttpContext = HttpAccessor.HttpContext;
    }
    public Task WriteBody(dynamic body, int statusCode)
    {

        string responseMessageSerialized = JsonConvert.SerializeObject(body);
        byte[] encodedReponseMessage = Encoding.UTF8.GetBytes(responseMessageSerialized);
        Response.OnStarting(async () =>
        {
            Response.ContentType = "application/json";
            Response.StatusCode = statusCode;
            await Response.Body.WriteAsync(encodedReponseMessage, offset: 0, count: encodedReponseMessage.Length);
            await Response.Body.FlushAsync();
        });
        return Task.CompletedTask;
    }
    public string GetAuthorizationHeader()
    {
        string header = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(header))
        {
            throw new HttpRequestException("token not provided, please provide a jwt token");
        }
        return header;
    }
    public string GetJwtToken()
    {
        return GetAuthorizationHeader().Split(' ')[1];
    }
}