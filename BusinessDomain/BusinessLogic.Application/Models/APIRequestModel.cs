namespace BusinessLogic.Application.Models;
public record APIRequestModel
{
    public string Url { get; set; } = string.Empty;
    public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
    public object? RequestContent { get; set; }
    public string APIName { get; set; } = string.Empty;
}